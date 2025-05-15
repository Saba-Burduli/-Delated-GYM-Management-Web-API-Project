using GymMembership.DATA.Entities;
using System.ComponentModel.DataAnnotations;

namespace GymMembership.SERVICE.DTOs.UserModels;

public class RoleModel
{
    public int RoleId { get; set; }
    public string? RoleName { get; set; } 
}