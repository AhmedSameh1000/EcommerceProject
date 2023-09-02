import { Component } from '@angular/core';
import { AuthService } from 'src/app/auth/Auth/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {
    constructor(public AuthService:AuthService){
      
    }

}
