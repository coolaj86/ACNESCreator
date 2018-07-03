﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACNESCreator.Core
{
    public enum BIFlags
    {
        None = 0,
        CI8 = 1,
        RGB5A3 = 2,
        Unknown = 3
    }

    public enum IconFormats
    {
        None = 0,
        Shared_CI8 = 1,
        RGB5A3 = 2,
        Unique_CI8 = 3
    }

    public enum AnimationSpeeds
    {
        None = 0,
        FourFrames = 1,
        EightFrames = 2,
        TwelveFrames = 3
    }

    public enum Permissions
    {
        Public = 0b0010, // 2
        NoCopy = 0b0100, // 4
        NoMove = 0b1000  // 8
    }

    public class GCI
    {
        #region DEFAULT ICON IMAGE DATA
        public static readonly byte[] DefaultIconData = new byte[]
        {
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x00, 0x02, 0x02, 0x02, 0x02, 0x02, 0x00, 0x07, 0x28,
            0x02, 0x02, 0x02, 0x00, 0x07, 0x28, 0x89, 0x8F, 0x02, 0x00, 0x07, 0x1F, 0x86, 0x8F, 0x8F, 0x8F,
            0x00, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x28, 0x0C, 0x05, 0x00, 0x02, 0x02, 0x02, 0x02,
            0x8F, 0x8C, 0x79, 0x1F, 0x0C, 0x00, 0x00, 0x02, 0x8F, 0x8F, 0x8F, 0x8F, 0x8C, 0x75, 0x1F, 0x0C,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x01, 0x02, 0x02, 0x02, 0x02, 0x02, 0x01, 0x03, 0x10,
            0x02, 0x02, 0x02, 0x02, 0x00, 0x10, 0x79, 0x8F, 0x02, 0x02, 0x00, 0x0C, 0x75, 0x8F, 0x8F, 0x8F,
            0x05, 0x1E, 0x81, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x7C, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F,
            0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F,
            0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8C, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8C, 0x6B,
            0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x7C, 0x65, 0x7B, 0x8F, 0x8F, 0x8F, 0x89, 0x6B, 0x6E, 0x81, 0x85,
            0x4C, 0x14, 0x07, 0x02, 0x02, 0x02, 0x02, 0x02, 0x38, 0x33, 0x35, 0x31, 0x14, 0x07, 0x02, 0x02,
            0x79, 0x60, 0x35, 0x38, 0x7C, 0x8B, 0x53, 0x0A, 0x81, 0x6E, 0x6B, 0x8C, 0x8F, 0x75, 0x53, 0x1B,
            0x02, 0x0C, 0x29, 0x8C, 0x8B, 0x8C, 0x8F, 0x8F, 0x0E, 0x6E, 0x81, 0x79, 0x81, 0x7C, 0x79, 0x81,
            0x12, 0x6E, 0x3E, 0x6B, 0x82, 0x8E, 0x8D, 0x86, 0x12, 0x79, 0x59, 0x84, 0x7D, 0x71, 0x73, 0x89,
            0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8C, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F, 0x8F,
            0x79, 0x79, 0x86, 0x8D, 0x8F, 0x8F, 0x8D, 0x75, 0x8F, 0x8D, 0x7E, 0x79, 0x7E, 0x7C, 0x6B, 0x7C,
            0x8F, 0x8D, 0x79, 0x69, 0x7C, 0x81, 0x81, 0x79, 0x86, 0x6B, 0x75, 0x81, 0x81, 0x7E, 0x6B, 0x73,
            0x6B, 0x7E, 0x81, 0x81, 0x79, 0x6B, 0x81, 0x8F, 0x85, 0x81, 0x7E, 0x6E, 0x75, 0x8D, 0x8F, 0x6E,
            0x65, 0x7E, 0x8F, 0x89, 0x53, 0x49, 0x58, 0x1B, 0x8D, 0x8F, 0x73, 0x49, 0x4C, 0x58, 0x58, 0x1D,
            0x89, 0x53, 0x49, 0x53, 0x58, 0x58, 0x4C, 0x18, 0x45, 0x4C, 0x58, 0x58, 0x53, 0x45, 0x3A, 0x18,
            0x10, 0x75, 0x60, 0x49, 0x70, 0x83, 0x77, 0x67, 0x11, 0x51, 0x54, 0x60, 0x5A, 0x4E, 0x53, 0x65,
            0x0D, 0x6A, 0x5E, 0x52, 0x55, 0x5C, 0x65, 0x5F, 0x00, 0x26, 0x47, 0x32, 0x47, 0x56, 0x51, 0x54,
            0x6B, 0x7C, 0x8C, 0x8C, 0x53, 0x30, 0x45, 0x65, 0x6E, 0x6E, 0x6B, 0x44, 0x30, 0x36, 0x35, 0x31,
            0x53, 0x50, 0x65, 0x3E, 0x2B, 0x2E, 0x30, 0x3E, 0x65, 0x65, 0x60, 0x38, 0x2B, 0x2C, 0x2B, 0x58,
            0x7C, 0x79, 0x6B, 0x85, 0x8F, 0x86, 0x4C, 0x45, 0x35, 0x75, 0x8F, 0x8F, 0x6E, 0x45, 0x4C, 0x58,
            0x81, 0x8F, 0x86, 0x4C, 0x45, 0x58, 0x58, 0x57, 0x6B, 0x63, 0x45, 0x4C, 0x58, 0x58, 0x4C, 0x3E,
            0x53, 0x58, 0x58, 0x49, 0x39, 0x42, 0x47, 0x07, 0x58, 0x53, 0x3E, 0x3C, 0x48, 0x52, 0x37, 0x02,
            0x49, 0x3A, 0x43, 0x4B, 0x4F, 0x42, 0x0E, 0x02, 0x3D, 0x4A, 0x4B, 0x4A, 0x37, 0x07, 0x02, 0x02,
            0x02, 0x07, 0x4A, 0x32, 0x2E, 0x56, 0x6D, 0x64, 0x02, 0x00, 0x1A, 0x5D, 0x5D, 0x6A, 0x6C, 0x6A,
            0x02, 0x02, 0x02, 0x07, 0x19, 0x4A, 0x64, 0x6D, 0x02, 0x02, 0x02, 0x02, 0x02, 0x04, 0x0B, 0x24,
            0x56, 0x51, 0x61, 0x38, 0x2B, 0x2E, 0x2E, 0x75, 0x6C, 0x6C, 0x64, 0x34, 0x2B, 0x2B, 0x2E, 0x74,
            0x6C, 0x6A, 0x6C, 0x3F, 0x2B, 0x2C, 0x2E, 0x4D, 0x5D, 0x6C, 0x6D, 0x3F, 0x2B, 0x2B, 0x2F, 0x5E,
            0x79, 0x49, 0x4C, 0x58, 0x53, 0x45, 0x3A, 0x47, 0x7E, 0x58, 0x4C, 0x4C, 0x3B, 0x41, 0x4B, 0x4B,
            0x6B, 0x4C, 0x39, 0x3C, 0x48, 0x4B, 0x4B, 0x47, 0x5D, 0x34, 0x37, 0x41, 0x47, 0x4B, 0x37, 0x0A,
            0x4B, 0x4B, 0x42, 0x16, 0x05, 0x02, 0x02, 0x02, 0x4A, 0x37, 0x0A, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x17, 0x05, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x01, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x07, 0x1C, 0x52, 0x3A, 0x2B, 0x2B, 0x2F, 0x5E, 0x02, 0x02, 0x05, 0x09, 0x20, 0x2E, 0x2D, 0x40,
            0x02, 0x02, 0x00, 0x08, 0x05, 0x06, 0x13, 0x4D, 0x02, 0x0C, 0x28, 0x73, 0x65, 0x12, 0x06, 0x27,
            0x5D, 0x66, 0x81, 0x80, 0x54, 0x21, 0x04, 0x02, 0x88, 0x8C, 0x3E, 0x2F, 0x60, 0x6B, 0x0C, 0x00,
            0x79, 0x86, 0x46, 0x2A, 0x33, 0x72, 0x7A, 0x1E, 0x8A, 0x6B, 0x85, 0x7C, 0x5B, 0x83, 0x83, 0x7F,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x00, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x28, 0x07, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x05, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x07,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x07, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x23, 0x89, 0x7E, 0x2B, 0x2F, 0x79, 0x6F, 0x4E, 0x58, 0x60, 0x75, 0x7C, 0x65, 0x59, 0x71, 0x84,
            0x63, 0x75, 0x65, 0x58, 0x6E, 0x7C, 0x78, 0x7D, 0x07, 0x1B, 0x60, 0x75, 0x6B, 0x53, 0x62, 0x76,
            0x75, 0x8A, 0x6E, 0x7C, 0x86, 0x68, 0x83, 0x7D, 0x72, 0x73, 0x8A, 0x79, 0x6E, 0x86, 0x7C, 0x87,
            0x70, 0x76, 0x6B, 0x86, 0x7E, 0x6B, 0x7E, 0x65, 0x7C, 0x7C, 0x45, 0x49, 0x81, 0x81, 0x49, 0x65,
            0x87, 0x7E, 0x0A, 0x02, 0x02, 0x02, 0x02, 0x02, 0x81, 0x6B, 0x38, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x53, 0x65, 0x49, 0x02, 0x02, 0x02, 0x02, 0x02, 0x58, 0x1B, 0x07, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x02, 0x02, 0x04, 0x0F, 0x53, 0x75, 0x6E, 0x53, 0x02, 0x02, 0x02, 0x02, 0x01, 0x0A, 0x25, 0x75,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x00, 0x07, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x4C, 0x4C, 0x4C, 0x22, 0x0C, 0x6E, 0x45, 0x1B, 0x50, 0x3E, 0x0F, 0x02, 0x02, 0x05, 0x07, 0x02,
            0x15, 0x07, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x07, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
            0x02, 0x22, 0x03, 0x32, 0x03, 0x33, 0x12, 0x22, 0x13, 0x32, 0x13, 0x33, 0x22, 0x22, 0x23, 0x33,
            0x24, 0x44, 0x32, 0x23, 0x33, 0x33, 0x34, 0x34, 0x34, 0x44, 0x34, 0x45, 0x43, 0x33, 0x44, 0x44,
            0x45, 0x55, 0x45, 0x56, 0x46, 0x66, 0x51, 0x11, 0x52, 0x22, 0x53, 0x33, 0x53, 0x34, 0x54, 0x34,
            0x54, 0x44, 0x55, 0x45, 0x55, 0x46, 0x55, 0x55, 0x55, 0x56, 0x56, 0x65, 0x56, 0x66, 0x57, 0x77,
            0x62, 0x22, 0x63, 0x34, 0x64, 0x44, 0x65, 0x55, 0x66, 0x57, 0x66, 0x66, 0x66, 0x68, 0x67, 0x77,
            0x68, 0x88, 0x6A, 0xAA, 0x84, 0x21, 0x8C, 0x63, 0x90, 0x63, 0x90, 0x64, 0x90, 0x84, 0x94, 0xA5,
            0x98, 0xC6, 0x9C, 0xE7, 0x9C, 0xE8, 0xA1, 0x08, 0xA1, 0x0A, 0xA5, 0x29, 0xA9, 0x29, 0xA9, 0x2C,
            0xA9, 0x4A, 0xA9, 0x4B, 0xA9, 0x4C, 0xAD, 0x4B, 0xAD, 0x4D, 0xAD, 0x4E, 0xAD, 0x6B, 0xAD, 0x6D,
            0xB1, 0x6D, 0xB1, 0x6E, 0xB1, 0x6F, 0xB1, 0x70, 0xB1, 0x8B, 0xB1, 0x8C, 0xB5, 0x8C, 0xB5, 0x90,
            0xB5, 0x91, 0xB5, 0xAD, 0xB9, 0xB1, 0xB9, 0xB2, 0xB9, 0xCE, 0xB9, 0xCF, 0xBA, 0x0F, 0xBD, 0xB2,
            0xBD, 0xCE, 0xBD, 0xD1, 0xBD, 0xD3, 0xBD, 0xEF, 0xC1, 0xF1, 0xC1, 0xF2, 0xC1, 0xF4, 0xC2, 0x0F,
            0xC2, 0x10, 0xC2, 0x31, 0xC2, 0x51, 0xC6, 0x10, 0xC6, 0x11, 0xC6, 0x15, 0xC6, 0x16, 0xC6, 0x30,
            0xC6, 0x31, 0xC6, 0x32, 0xC6, 0x52, 0xCA, 0x31, 0xCA, 0x37, 0xCA, 0x52, 0xCA, 0x53, 0xCA, 0x73,
            0xCD, 0xEF, 0xCE, 0x52, 0xCE, 0x58, 0xCE, 0x73, 0xD2, 0x58, 0xD2, 0x79, 0xD2, 0x94, 0xD2, 0xB5,
            0xD5, 0x4A, 0xD5, 0xAD, 0xD6, 0x73, 0xD6, 0x94, 0xD6, 0xB4, 0xD6, 0xB5, 0xD6, 0xD6, 0xDA, 0x10,
            0xDA, 0x94, 0xDA, 0xD6, 0xDA, 0xF7, 0xDE, 0xD6, 0xDE, 0xF7, 0xE1, 0x29, 0xE3, 0x18, 0xE6, 0xB5,
            0xE7, 0x38, 0xE7, 0x39, 0xE7, 0x5A, 0xE8, 0xA5, 0xE9, 0xCE, 0xEB, 0x39, 0xEB, 0x5A, 0xEB, 0x7B,
            0xEF, 0x7A, 0xEF, 0x7B, 0xF3, 0x7B, 0xF3, 0x9C, 0xF7, 0xBD, 0xFB, 0xDE, 0xFB, 0xFF, 0xFF, 0xFF,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        };
        #endregion

        internal static char[] PadString(string Input, int Length)
        {
            char[] Out = Input.ToCharArray();
            Array.Resize(ref Out, Length);
            return Out;
        }

        const int GCIHeaderSize = 0x40;
        const int BlockSize = 0x2000;
        internal static readonly long Epoch = new DateTime(2000, 1, 1).Ticks; // Ticks after UTC epoch on Jan 1st, 2000. 

        public GCIHeader Header;
        public string Comment1;
        public string Comment2;
        public byte[] ImageData;
        public byte[] Data
        {
            get => _data;
            set
            {
                _data = value;
                Header.BlockCount = (ushort)((value.Length / BlockSize) + 1);
            }
        }

        private byte[] _data;

        public sealed class GCIHeader
        {
            public string GameCode;
            public string MakerCode;
            public byte Unused1;
            public byte BIFlags;
            public string FileName;
            public int ModTime;
            public int ImageOffset;
            public ushort IconFormat;
            public ushort AnimationSpeed;
            public byte PermissionsFlags;
            public byte CopyCounter;
            public ushort FirstBlock;
            public ushort BlockCount;
            public ushort Unused2;
            public int CommentOffset;

            public GCIHeader(byte[] Data)
            {
                GameCode = Encoding.ASCII.GetString(Data, 0, 4);
                MakerCode = Encoding.ASCII.GetString(Data, 3, 2);
                Unused1 = Data[6];
                BIFlags = Data[7];
                FileName = Encoding.ASCII.GetString(Data, 8, 32);
                ModTime = BitConverter.ToInt32(Data, 0x28).Reverse();
                ImageOffset = BitConverter.ToInt32(Data, 0x2C).Reverse();
                IconFormat = BitConverter.ToUInt16(Data, 0x30).Reverse();
                AnimationSpeed = BitConverter.ToUInt16(Data, 0x32).Reverse();
                PermissionsFlags = Data[0x34];
                CopyCounter = Data[0x35];
                FirstBlock = BitConverter.ToUInt16(Data, 0x36).Reverse();
                BlockCount = BitConverter.ToUInt16(Data, 0x38).Reverse();
                Unused2 = BitConverter.ToUInt16(Data, 0x3A).Reverse();
                CommentOffset = BitConverter.ToInt32(Data, 0x3C).Reverse();
            }

            public GCIHeader()
            {
                GameCode = "GAFE";
                MakerCode = "01";
                Unused1 = 0xFF;
                BIFlags = 0; // No banner
                FileName = "DobutsunomoriP_F_GAME";
                ModTime = (int)new TimeSpan(DateTime.Now.Ticks - Epoch).TotalSeconds;
                ImageOffset = 0x40;
                IconFormat = (ushort)IconFormats.Shared_CI8;
                AnimationSpeed = (ushort)AnimationSpeeds.EightFrames;
                PermissionsFlags = (byte)Permissions.NoCopy;
                CopyCounter = 0;
                FirstBlock = 0;
                BlockCount = 1;
                Unused2 = 0xFFFF;
                CommentOffset = 0;
            }

            public byte[] GetData()
            {
                byte[] HeaderData = new byte[GCIHeaderSize];
                Encoding.ASCII.GetBytes(PadString(GameCode, 4), 0, 4).CopyTo(HeaderData, 0);
                Encoding.ASCII.GetBytes(PadString(MakerCode, 2), 0, 2).CopyTo(HeaderData, 4);
                HeaderData[6] = Unused1;
                HeaderData[7] = BIFlags;
                Encoding.ASCII.GetBytes(PadString(FileName, 32), 0, 32).CopyTo(HeaderData, 8);
                BitConverter.GetBytes(ModTime.Reverse()).CopyTo(HeaderData, 0x28);
                BitConverter.GetBytes(ImageOffset.Reverse()).CopyTo(HeaderData, 0x2C);
                BitConverter.GetBytes(IconFormat.Reverse()).CopyTo(HeaderData, 0x30);
                BitConverter.GetBytes(AnimationSpeed.Reverse()).CopyTo(HeaderData, 0x32);
                HeaderData[0x34] = PermissionsFlags;
                HeaderData[0x35] = CopyCounter;
                BitConverter.GetBytes(FirstBlock.Reverse()).CopyTo(HeaderData, 0x36);
                BitConverter.GetBytes(BlockCount.Reverse()).CopyTo(HeaderData, 0x38);
                BitConverter.GetBytes(Unused2.Reverse()).CopyTo(HeaderData, 0x3A);
                BitConverter.GetBytes(CommentOffset.Reverse()).CopyTo(HeaderData, 0x3C);

                return HeaderData;
            }
        }

        public GCI(byte[] IconData = null)
        {
            Header = new GCIHeader();
            Comment1 = "Animal Crossing";
            Comment2 = "NES Game";
            ImageData = IconData ?? DefaultIconData;
            Data = new byte[0];
        }

        public GCI(byte[] HeaderData, byte[] CommentData, byte[] BannerData, byte[] IconData)
        {
            Header = new GCIHeader(HeaderData);
            Comment1 = Encoding.GetEncoding("shift-jis").GetString(CommentData, 0, 32);
            Comment2 = Encoding.GetEncoding("shift-jis").GetString(CommentData, 0x20, 32);
            if ((IconFormats)Header.IconFormat == IconFormats.Shared_CI8)
            {
                ImageData = IconData.Skip(Header.ImageOffset + GCIHeaderSize).Take(0x600).ToArray();
            }

            Data = Data.Skip(0x640).ToArray();
        }

        public byte[] GetData()
        {
            List<byte> Data = new List<byte>();
            Data.AddRange(Header.GetData());
            while (Header.CommentOffset >= Data.Count)
            {
                Data.Add(0);
            }

            byte[] Comment1Data = Encoding.GetEncoding("shift-jis").GetBytes(Comment1);
            Array.Resize(ref Comment1Data, 32);
            Data.AddRange(Comment1Data);
            byte[] Comment2Data = Encoding.GetEncoding("shift-jis").GetBytes(Comment2);
            Array.Resize(ref Comment2Data, 32);
            Data.AddRange(Comment2Data);

            while (Header.ImageOffset >= Data.Count)
            {
                Data.Add(0);
            }

            Data.AddRange(ImageData);

            while (Data.Count < 0x680)
            {
                Data.Add(0); // Pad to 0x680
            }

            Data.AddRange(this.Data);

            byte[] Output = Data.ToArray();
            Array.Resize(ref Output, GCIHeaderSize + Header.BlockCount * 0x2000);
            return Output;
        }
    }
}
