import { Component } from '@angular/core';
import { Pagination } from 'src/app/shared/Models/Paging';
import { UserService } from '../UserService/user.service';
import { params } from 'src/app/shared/Models/params';
import Swal from 'sweetalert2'
import { MatDialog } from '@angular/material/dialog';
import { MangeUserComponent } from '../mange-user/mange-user.component';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent {
  Pagination!:any
  constructor(private UserService:UserService,
    private matDialog:MatDialog
    ){
  }
  ngOnInit(): void {
    this.LoadUsers()
  }
  AllParams=new params()
  LoadUsers(){
    this.UserService.GetUsers(this.AllParams).subscribe({
      next:(res)=>{
        this.Pagination=res;
        console.log(res)
     
      },
      error:(e)=>console.log(e)
    })
  }

  change(event:any){
    this.AllParams.page=event.page;
    this.LoadUsers()
  }
  delete(id:number,Div:HTMLElement){
    Swal.fire({
      title: 'Are you sure?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) 
      {
     this.UserService.DeleteUser(id).subscribe
     ({
          next:(res)=>{
            Div.remove()
            Swal.fire(
              'Deleted!',
              'User has been deleted.',
              'success'
            )
      }
     })
      }
    })
  }
  Open(id:any){
    var dialogRef= this.matDialog.open(MangeUserComponent,{
       data:id,
       width:"700px"
    })
    dialogRef.afterClosed().subscribe(res=>{
      if(res){
        this.LoadUsers()
      }
    })
  }
}
