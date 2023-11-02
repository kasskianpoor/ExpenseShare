import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { map } from 'rxjs';
import { paths } from '../_constants';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const router = inject(Router);

  return accountService.getCurrentUser().pipe(
    map((user) => {
      if (user) {
        return true;
      } else {
        router.navigate([paths.login]);
        return false;
      }
    })
  );
};
