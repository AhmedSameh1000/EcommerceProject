import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../auth/Auth/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  return inject(AuthService).isAdmin()||inject(AuthService).isModerator()?true&&inject(Router).navigate(['/']):false
};
