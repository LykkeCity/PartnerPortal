import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product.model';

@Component({
  selector: 'lpp-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  products: Product[];
  areProductsEven: boolean;

  constructor(private http:HttpClient) {
    this.products = [
      {title: 'Lykke Trading Wallet', description: 'Trade FX and Digital Assets', imageUrl: '../../assets/images/products/lykke_wallet_ios_android.png'},
      {title: 'Lykke Margin Trading', description: 'FX and Crypto Margin Trading', imageUrl: '../../assets/images/products/lykke_margin_trading.png'},
      {title: 'Lykke Pay', description: 'Payments on blockchain', imageUrl: '../../assets/images/products/lykke_pay.png'},
      {title: 'Lykke Exchange', description: 'Trading platform and API', imageUrl: '../../assets/images/products/lykke_exchange.png'},
      {title: 'POS Terminal', description: 'POS handheld terminal', imageUrl: '../../assets/images/products/lykke_pos_terminal.png'},
      {title: 'Modern money', description: 'Personal finance application', imageUrl: '../../assets/images/products/modern_money.png'},
      {title: 'Lykke.blue', description: 'Natural capital investment', imageUrl: '../../assets/images/products/lykke_blue.png'}
    ];

    this.areProductsEven = this.products.length % 2 === 0;
  }

  ngOnInit() {
    this.http.get('/api/products', {responseType: 'text'}).subscribe(val => {
      this.products = JSON.parse(val);
      this.areProductsEven = this.products.length % 2 === 0;
    })
  }
}
