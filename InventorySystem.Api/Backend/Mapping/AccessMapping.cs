// using System;
// using Backend.Dtos;
// using Backend.Entities;

// namespace Backend.Mapping;

// public static class AccessMapping1
// {

// //CRUD

//     //READ
//     public static AccessDto ToListAccess(this User AccessDto)
//     {
//         return new(
//             AccessDto.Id,
//             AccessDto.ApprovalStatus.ToString()
//         );
//     }

//     //READ by id
//     public static AccessDto ToListAccess(this User AccessDto, int id)
//     {
//         return new(
//             AccessDto.Id,
//             AccessDto.ApprovalStatus.ToString()
//         );
//     }

//     //CREATE
//     public static Access ToAccessEntity(this AddAccessDto item)
//     {
//         return new Access()
//         {
//             AccessName = item.Access
//         };
//     }

//     //UPDATE
//     public static Access ToUpdateAccessEntity(this AddAccessDto item, int id)
//     {
//         return new Access()
//         {
//             Id = id,
//             AccessName = item.Access
//         };
//     }
// }
