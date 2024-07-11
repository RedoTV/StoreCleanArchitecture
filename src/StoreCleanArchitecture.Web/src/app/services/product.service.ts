import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_URL } from '../app.config';
import { Observable, map } from 'rxjs';
import Product from '../models/product';


@Injectable()
export class ProductService {
  http: HttpClient;

  constructor(http : HttpClient) {
    this.http = http;
  }

  getAllProducts() : Observable<Product[]>
  {
    return this.http.get<Product[]>(`${API_URL}/Product/GetFromService`);
  }
}
