import { IProduct } from './product'

export interface IProductLine {
  productLineId: number;
  amount: number;
  product: IProduct;
}
