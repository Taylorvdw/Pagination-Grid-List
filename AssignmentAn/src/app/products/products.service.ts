import { ProdParams } from './../shared/models/prodParams';
import { IPagination } from '../shared/models/pagination';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IType } from '../shared/models/prodtype';
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }
  getProducts(prodParams: ProdParams) {
    let params = new HttpParams();
    console.log('prodParams.typeId')
    if (prodParams.typeId > 0) {

      params = params.append('typeId', prodParams.typeId.toString());
    }
    params = params.append("sort", prodParams.sort);
    params = params.append('pageIndex', prodParams.pageNumber.toString());
    params = params.append('pageSize', prodParams.pageSize.toString());


    return this.http.get<IPagination>(this.baseUrl + 'Product', {observe: 'response', params})
    .pipe(map(response => {
      return response.body;
    }))
  }
  GetTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'Product/types');
  }
}
