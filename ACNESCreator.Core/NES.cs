﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ACNESCreator.Core
{
    public enum Region
    {
        Japan = 0,
        NorthAmerica = 1,
        Europe = 2,
        Australia = 3
    }

    public class NES
    {
        const ushort DefaultTagSize = 0x10;
        const ushort DefaultBannerDataSize = 0x40;
        const byte DefaultFlags1 = 0xE2;
        const byte DefaultFlags2 = 0;
        const string DefaultTagData = "END\0";
        readonly string[] RegionCodes = new string[4] { "J", "E", "P", "U" };

        public class ACNESHeader
        {
            public byte Checksum = 0; // May not be the checksum byte.
            public byte Unknown1 = 0; // May not be used.
            public string Name;
            public ushort DataSize;
            public ushort TagsSize;
            public ushort IconFormat;
            public ushort Unknown2 = 0; // Not sure what this is. TODO: Figure it out.
            public ushort BannerSize;
            public byte Flags1;
            public byte Flags2;
            public ushort Padding; // 0 Padding? Doesn't appear to be used.

            public byte[] GetData()
            {
                byte[] Data = new byte[0x20];

                Data[0] = Checksum;
                Data[1] = Unknown1;
                Utility.GetPaddedStringData(Name, 0x10, 0x20).CopyTo(Data, 2);
                BitConverter.GetBytes(DataSize.Reverse()).CopyTo(Data, 0x12);
                BitConverter.GetBytes(TagsSize.Reverse()).CopyTo(Data, 0x14);
                BitConverter.GetBytes(IconFormat.Reverse()).CopyTo(Data, 0x16);
                BitConverter.GetBytes(Unknown2.Reverse()).CopyTo(Data, 0x18);
                BitConverter.GetBytes(BannerSize.Reverse()).CopyTo(Data, 0x1A);
                Data[0x1C] = Flags1;
                Data[0x1D] = Flags2;
                BitConverter.GetBytes(Padding.Reverse()).CopyTo(Data, 0x1E);

                return Data;
            }
        }

        public class Banner
        {
            public string Title;
            public string Comment;
            public byte[] BannerData = new byte[0];
            public byte[] IconData = new byte[0];

            public byte[] GetData()
            {
                List<byte> Data = new List<byte>();
                if (!string.IsNullOrEmpty(Title) || !string.IsNullOrEmpty(Comment))
                {
                    Data.AddRange(Utility.GetPaddedStringData(Title, 0x20));
                    Data.AddRange(Utility.GetPaddedStringData(Comment, 0x20));
                }

                Data.AddRange(BannerData);
                Data.AddRange(IconData);

                return Data.ToArray();
            }
        }

        public readonly ACNESHeader Header;
        public readonly byte[] TagData;
        public readonly Banner BannerData;
        public readonly byte[] ROM;

        public readonly Region GameRegion;

        public NES(string ROMName, byte[] ROMData, Region ACRegion)
        {
            if (!IsNESImage(ROMData))
            {
                throw new ArgumentException("ROMData must be a valid NES image!");
            }

            if (ROMName == null || ROMName.Length < 4 || ROMName.Length > 0x10)
            {
                throw new ArgumentException("ROMName cannot be less than 4 characters or longer than 16 characters.");
            }

            Header = new ACNESHeader
            {
                Name = ROMName,
                DataSize = (ushort)((ROMData.Length + 0xF) >> 4),
                TagsSize = DefaultTagSize,
                IconFormat = (ushort)IconFormats.Shared_CI8,
                Unknown2 = 0,
                BannerSize = DefaultBannerDataSize,
                Flags1 = DefaultFlags1,
                Flags2 = DefaultFlags2,
                Padding = 0
            };

            TagData = Utility.GetPaddedStringData(DefaultTagData, 0x10);

            BannerData = new Banner
            {
                Title = "Animal Crossing",
                Comment = ROMName + "\n" + "NES Save Data"
            };

            ROM = ROMData;

            GameRegion = ACRegion;
        }

        internal bool IsNESImage(byte[] Data)
            => Encoding.ASCII.GetString(Data, 0, 3) == "NES";

        internal void SetChecksum(ref byte[] Data)
        {
            byte Checksum = 0;
            for (int i = 0x40; i < Data.Length; i++) // Skip the header by adding 0x40
            {
                Checksum += Data[i];
            }

            Data[0x680] = (byte)-Checksum;
        }

        public byte[] GenerateGCIFile()
        {
            List<byte> Data = new List<byte>();
            Data.AddRange(Header.GetData());
            Data.AddRange(TagData);
            Data.AddRange(BannerData.GetData());
            Data.AddRange(ROM);

            var BlankGCIFile = new GCI
            {
                Data = Data.ToArray(),
                Comment1 = "Animal Crossing",
                Comment2 = "NES Game:\n" + Header.Name,
            };

            BlankGCIFile.Header.FileName = "DobutsunomoriP_F_" + Header.Name.Substring(0, 4).ToUpper();
            BlankGCIFile.Header.GameCode = "GAF" + RegionCodes[(int)GameRegion];

            byte[] GCIData = BlankGCIFile.GetData();
            SetChecksum(ref GCIData);

            return GCIData;
        }
    }
}
