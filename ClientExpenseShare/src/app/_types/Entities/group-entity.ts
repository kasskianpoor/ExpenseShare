import { expenseEntity } from './expense-entity';
import { userEntity } from './user-entity';

export type groupEntity = {
  id: number;
  name: string;
  users?: userEntity[];
  expenses?: expenseEntity[];
};
