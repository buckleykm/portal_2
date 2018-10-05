import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import {UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { App } from '../_models/app';

@Injectable()
export class UserAppListResolver implements Resolve<App[]> {
    pageNumber = 1;
    pageSize = 25;

    constructor(private userService: UserService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<App[]> {
        return this.userService.getAppsForUser(route.params['userId']).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/apps']);
                return of(null);
            })
        );
    }
}
