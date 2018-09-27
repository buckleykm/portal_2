import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BrokerQuotesComponent } from 'src/app/broker-quotes/broker-quotes.component';
import { BrokerAppsComponent } from './broker-apps/broker-apps.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'apps', component: BrokerAppsComponent, canActivate: [AuthGuard] },
            { path: 'quotes', component: BrokerQuotesComponent },
        ]
    },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
