import { IPagination } from './shared/models/pagination';
import { IProduct } from './shared/models/product';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'AssignmentAn';
  products: IProduct[] | undefined;


  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<IPagination>('https://localhost:5001/api/product').subscribe((response: IPagination) => {
      this.products = response.data
    }, error => {
      console.log(error);
    })
  }
}
