import { ICoinBudget } from './coin-budget';

export interface IOperationResult {
  success: boolean;
  message: string;
  coinsReturned: ICoinBudget[];
  total: number;
}

export class OperationResult implements IOperationResult {
  success: boolean;
  message: string;
  coinsReturned: ICoinBudget[];
  total: number;
}
