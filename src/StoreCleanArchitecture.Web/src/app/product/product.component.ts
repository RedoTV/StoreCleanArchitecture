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

  public products: Product[] = [{name: "Tom", id: 4}];

  constructor(private productService: ProductService) {

  }

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe(
      (data:Product[]) => this.products = data,
      (err: Error) => console.log(err.message)
    )
  }

}
