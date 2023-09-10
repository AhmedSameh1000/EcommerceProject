import { Component, Inject, OnInit } from '@angular/core';
import { UserService } from '../UserService/user.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup } from '@angular/forms';
import { userRole } from 'src/app/shared/Models/userRole';
import { role } from 'src/app/shared/Models/role';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-mange-user',
  templateUrl: './mange-user.component.html',
  styleUrls: ['./mange-user.component.css']
})
export class MangeUserComponent implements OnInit {
    constructor(private UserService:UserService,
      private matDialogRef:MatDialogRef<MangeUserComponent>,
     private Toaster:ToastrService,
      @Inject(MAT_DIALOG_DATA) public data: {id: string}
      ){  
    }
  ngOnInit(): void {
  this.GetUserRoles()
  this.userRoles = { UserId: this.data, Roles:[],UserName:"" }; // تعريف UserRolesToChange هنا
  this.Role = {} as role; 
  }
 UserWithRoles!:userRole

 GetUserRoles(){
  this.UserService.GetUserRoles(this.data).subscribe({
    next:(res)=>{
      this.UserWithRoles=res

    }
  })
 }
 Close(){
  this.matDialogRef.close(null)
 }

 userRoles!:any
Role!:any
 DoSomeThing(roleId:any,roleName:any,inp:HTMLInputElement){
  const newRole: any = {
    IsSelected: inp.checked,
    RoleId: roleId,
    RoleName: roleName
  };

  // Find the index of the existing role (if it exists) with the same RoleId
  const existingRoleIndex = this.userRoles.Roles.findIndex(
    (role: any) => role.RoleId === roleId
  );

  // If the role already exists in the userRoles.Roles array, update it
  if (existingRoleIndex !== -1) {
    this.userRoles.Roles[existingRoleIndex] = newRole;
  } else {
    // If it doesn't exist, push the new role
    this.userRoles.Roles.push(newRole);
  }
  }
 

    Create(){
      let ar=["sda",'das']
      ar.join("|")
      this.UserService.SetUserRoles(this.userRoles).subscribe({
        next:(res)=>{
          this.matDialogRef.close(true)
        },
        complete:()=>{
          this.Toaster.success("User Updated Succesfuly")
        }
      })
    }

}










// DoSomeThing(roleId:any,roleName:any,inp:HTMLInputElement){
//   this.Role.IsSelected=inp.checked;
//   this.Role.RoleId=roleId;
//   this.Role.RoleName=roleName
//   let roles:any[]=[]


//   roles.push(this.Role)
//    this.userRoles={
//     UserId:this.UserWithRoles.userId,
//     Roles:roles,
//     UserName:"Ahmed"
//    }

//   }