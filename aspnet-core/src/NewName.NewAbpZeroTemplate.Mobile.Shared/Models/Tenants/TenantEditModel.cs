﻿using System.ComponentModel;
using Abp.AutoMapper;
using NewName.NewAbpZeroTemplate.MultiTenancy.Dto;

namespace NewName.NewAbpZeroTemplate.Models.Tenants
{
    [AutoMapFrom(typeof(TenantEditDto))]
    public class TenantEditModel : TenantEditDto, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}