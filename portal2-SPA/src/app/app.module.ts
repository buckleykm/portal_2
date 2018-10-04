import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule, PaginationModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { AgGridModule } from 'ag-grid-angular';


import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { BrokerQuotesComponent } from './brokers/broker-quotes/broker-quotes.component';
import { BrokerAppsComponent } from './brokers/broker-apps/broker-apps.component';
import { appRoutes } from './routes';
import { AuthGuard } from './_guards/auth.guard';
import { BrokerService } from './_services/broker.service';
import { BrokerAppListResolver } from './_resolvers/brokerAppList.resolver';



export function tokenGetter() {
    return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      BrokerAppsComponent,
      BrokerQuotesComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      PaginationModule.forRoot(),
      JwtModule.forRoot({
          config: {
              tokenGetter: tokenGetter,
              whitelistedDomains: ['localhost:5000'],
              blacklistedRoutes: ['localhost:5000/api/auth']
          },
      }),
      AgGridModule.withComponents([])
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard,
      BrokerService,
      BrokerAppListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
