import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserQuotesComponent } from './users/user-quotes/user-quotes.component';
import { UserAppsComponent } from './users/user-apps/user-apps.component';
import { AuthGuard } from './_guards/auth.guard';
import { UserAppListResolver } from './_resolvers/userAppList.resolver';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'apps/:userId', component: UserAppsComponent,
                resolve: {apps: UserAppListResolver} },
            { path: 'quotes', component: UserQuotesComponent },
        ]
    },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
