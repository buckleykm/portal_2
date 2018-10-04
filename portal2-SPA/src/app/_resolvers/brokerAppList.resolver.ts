import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { BrokerService } from '../_services/broker.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { App } from '../_models/App';

@Injectable()
export class BrokerAppListResolver implements Resolve<App[]> {
    pageNumber = 1;
    pageSize = 25;

    constructor(private brokerService: BrokerService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<App[]> {
        return this.brokerService.getAppsForBroker(route.params['brokerid']).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/apps']);
                return of(null);
            })
        );
    }
}
