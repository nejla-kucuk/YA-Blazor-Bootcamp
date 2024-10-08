﻿using NK.ChatGPTClone.Domain.Common;
using NK.ChatGPTClone.Domain.Enums;
using NK.ChatGPTClone.Domain.ValueObjects;

namespace NK.ChatGPTClone.Domain.Entities
{
    public sealed class ChatSession : EntityBase  
    {
        // sealed ---> Miras vermeyecek olan sınıflar için gereklidir.

        public string Title { get; set; }

        public GptModelType Model { get; set; }

        public List<ChatThread> Threads { get; set; } 

        public Guid AppUserId { get; set; }

       

    }
}
