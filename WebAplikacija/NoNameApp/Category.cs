﻿namespace NoNameApp
{
    [System.Serializable]
    public class Category
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            Name = name;
        }
    }
}