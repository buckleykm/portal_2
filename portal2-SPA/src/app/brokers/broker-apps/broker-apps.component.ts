import { Component, OnInit } from '@angular/core';
import { BrokerService } from '../../_services/broker.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { App } from '../../_models/App';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-broker-apps',
  templateUrl: './broker-apps.component.html',
  styleUrls: ['./broker-apps.component.css']
})
export class BrokerAppsComponent implements OnInit {
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

  constructor(private brokerService: BrokerService, private alertify: AlertifyService,
    private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit() {
    // this.route.data.subscribe(data => {
    //   this.broker = data['broker'];
    // });

    // this.rowData = this.loadBrokerApps();

    this.rowData = this.http.get('http://localhost:5000/api/apps/1');

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

  loadBrokerApps() {
    this.brokerService.getAppsForBroker(+this.route.snapshot.params['brokerid']).subscribe((apps: App[]) => {
      this.apps = apps;
    }, error => {
      this.alertify.error(error);
    });
  }



  // getRows() {
  //   const rows = [];
  //   for (let i = 0; i < this.apps.length; i++) {
  //     rows.push({
  //       caseid: this.apps[i].caseId,
  //       polno: this.apps[i].polNo
  //       // apftnm: this.apps[i].apftnm,
  //       // apltnm: this.apps[i].apltnm,
  //       // submittd: this.apps[i].submittd,
  //       // placed: this.apps[i].placed,
  //       // status: this.apps[i].status,
  //       // premium: this.apps[i].premium
  //     });
  //   }
  //   return rows;
  // }

  //   pageChanged(event: any): void {
  //   this.pagination.currentPage = event.page;
  //   this.loadBrokerApps();
  // }


}
