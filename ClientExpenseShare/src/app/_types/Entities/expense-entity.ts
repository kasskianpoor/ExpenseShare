export type expenseEntity = {
  id: number;
  amount: number;
  createdAt: string;
  groupId: number;
  paidByUserId: number;
};

export type expenseEntityToBeCreated = {
  amount: number;
  groupId: number;
  paidByUserId: number;
};
