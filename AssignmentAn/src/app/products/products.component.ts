import { ProdParams } from './../shared/models/prodParams';
import { Component, OnInit } from '@angular/core';
import { IType } from '../shared/models/prodtype';
import { IProduct } from '../shared/models/product';
import { ProductsService } from './products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  products : IProduct[];
  types: IType[];
  prodParams = new ProdParams()
  totalCount: number;
  selectedsort = 'name';
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'}

  ];

  constructor(private prodService: ProductsService) { }

  ngOnInit() {
    this.getProducts();
    this.getTypes()
  }

  getProducts() {
    this.prodService.getProducts(this.prodParams).subscribe(response => {
      this.products = response.data;
      console.log(response.data)
      this.prodParams.pageNumber = response.pageIndex;
      this.prodParams.pageSize = response.pageSize;
      this.totalCount = response.count
    }, error => {
      console.log(error);
    })
  }

  getTypes() {
    this.prodService.GetTypes().subscribe(response => {
      this.types = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  onTypeSelected(typeId: number) {
    console.log(typeId)
    this.prodParams.typeId = typeId;
    this.getProducts();
  }

  onSortSelected(sort: string) {

    this.prodParams.sort = sort;
    this.getProducts();
  }
  onPageChanged(event: any) {
    this.prodParams.pageNumber = event.page;
    this.getProducts();
  }

}
