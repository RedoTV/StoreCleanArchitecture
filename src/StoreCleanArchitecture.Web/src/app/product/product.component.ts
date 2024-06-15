import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';

import { HttpClientModule } from '@angular/common/http';
import Product from '../models/product';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [HttpClientModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css',
  providers: [ProductService]
})
export class ProductComponent implements OnInit {

  private _productService: ProductService;
  public products: Product[] = [{name: "Tom", id: 4}];

  constructor(productService: ProductService) {
    this._productService = productService;
  }
  ngOnInit(): void {
    this.getAllProducts()
  }

  public getAllProducts()
  {
    let sub = this._productService.getAllProducts().subscribe(next => this.products = (next));
  }
}
