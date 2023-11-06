import { userEntity } from './user-entity';

export type expenseEntity = {
  id: number;
  amount: number;
  createdAt: string;
  groupId: number;
  paidByUser?: userEntity;
  paidByUserId?: number;
};

export type expenseEntityToBeCreated = {
  amount?: number;
  groupId: number;
  userId: number;
};
