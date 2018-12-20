﻿using System;

namespace heaven.APIs
{
    [Serializable]
    public class AWSObject
    {
        public string Service;
        public string Type;
        public string Region;
        public string Name;
        public string Arn;
        public string Description;
        public string LastModified;
        public string Version;
        public string Role;
        public object Object;

        public AWSObject()
        {
        }
    }
}