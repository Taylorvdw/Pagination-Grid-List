import { NgModule } from '@angular/core';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatListModule} from '@angular/material/list';
import {MatCardModule} from '@angular/material/card';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSelectModule} from '@angular/material/select';
import { PaginationModule } from "ngx-bootstrap/pagination";



@NgModule({
  imports: [
    MatGridListModule,
    MatListModule,
    MatCardModule,
    MatPaginatorModule,
    MatSelectModule,
    PaginationModule


  ],
  exports: [
    MatGridListModule,
    MatListModule,
    MatCardModule,
    MatPaginatorModule,
    MatSelectModule,
    PaginationModule
  ]
})
export class MaterialModule { }
