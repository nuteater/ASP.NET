﻿using System;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using NewName.NewAbpZeroTemplate.Friendships.Dto;

namespace NewName.NewAbpZeroTemplate.Chat.Dto
{
    public class GetUserChatFriendsWithSettingsOutput
    {
        public DateTime ServerTime { get; set; }
        
        public List<FriendDto> Friends { get; set; }

        public GetUserChatFriendsWithSettingsOutput()
        {
            Friends = new EditableList<FriendDto>();
        }
    }
}