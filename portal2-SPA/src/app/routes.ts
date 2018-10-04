import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BrokerQuotesComponent } from './brokers/broker-quotes/broker-quotes.component';
import { BrokerAppsComponent } from './brokers/broker-apps/broker-apps.component';
import { AuthGuard } from './_guards/auth.guard';
import { BrokerAppListResolver } from './_resolvers/brokerAppList.resolver';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'apps/:brokerid', component: BrokerAppsComponent,
                resolve: {apps: BrokerAppListResolver} },
            { path: 'quotes', component: BrokerQuotesComponent },
        ]
    },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
