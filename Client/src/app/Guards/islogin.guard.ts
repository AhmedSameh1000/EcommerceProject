import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../auth/Auth/auth.service';

export const isloginGuard: CanActivateFn = (route, state) => {
    const authService = inject(AuthService);
    const router = inject(Router);

    if (authService.IsLogIn()) {
      return true;
    } else {
      router.navigate(['/LogIn']);
      return false;
    }

};
