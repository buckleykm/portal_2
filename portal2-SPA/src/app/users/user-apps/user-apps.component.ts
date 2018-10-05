import { Component, OnInit } from '@angular/core';
import { UserService } from '../../_services/user.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { App } from '../../_models/app';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';


@Component({
  selector: 'app-user-apps',
  templateUrl: './user-apps.component.html',
  styleUrls: ['./user-apps.component.css']
})
export class UserAppsComponent implements OnInit {
  baseUrl = environment.apiUrl;
  apps: App[];
  rowData: any;
  columnDefs = [
    {headerName: 'CaseID', field: 'caseId', width: 110},
    {headerName: 'Policy#', field: 'polNo', width: 125},
    {headerName: 'First', field: 'apftnm', width: 125},
    {headerName: 'Last', field: 'apltnm', width: 125},
    {headerName: 'Submitted', field: 'submittd', type: 'dateColumn'},
    {headerName: 'Placed', field: 'placed', type: 'dateColumn'},
    {headerName: 'Status', field: 'status', width: 250},
    {headerName: 'Ann. Prem.', field: 'premium'}

];

  constructor(private userService: UserService, private alertify: AlertifyService,
    private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit() {
    this.rowData = this.http.get(this.baseUrl + 'apps/' + this.route.snapshot.params['userId']);
    // this.rowData = this.http.get('http://localhost:5000/api/apps/1');
   }

  // loadBrokers () {
  //   this.brokerService.getBrokers(this.pagination.currentPage, this.pagination.itemsPerPage)
  //   .subscribe((res: PaginatedResult<Broker[]>) => {
  //     this.brokers = res.result;
  //     this.pagination = res.pagination;
  //   }, error => {
  //     this.alertify.error(error);
  //   });
  // }

  loadUserApps() {
    this.userService.getAppsForUser(+this.route.snapshot.params['userId']).subscribe((apps: App[]) => {
      this.apps = apps;
    }, error => {
      this.alertify.error(error);
    });
  }
}
