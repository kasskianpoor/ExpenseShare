import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountService } from './account.service';
import { mainBackendUrl } from '../_constants';
import {
  expenseEntity,
  expenseEntityToBeCreated,
} from '../_types/Entities/expense-entity';
import { IPaginatedData } from '../_interfaces/paginated-data';

@Injectable({
  providedIn: 'root',
})
export class ExpensesService {
  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) {}

  createExpense(input: expenseEntityToBeCreated) {
    return this.http.post<expenseEntity>(
      `${mainBackendUrl}/api/expenses`,
      input,
      {
        headers: { Authorization: `Bearer ${this.accountService.token}` },
      }
    );
  }

  editExpense(input: expenseEntity) {
    return this.http.put<expenseEntity>(
      `${mainBackendUrl}/api/expenses`,
      {
        expenseId: input.id,
        amount: input.amount,
      },
      {
        headers: { Authorization: `Bearer ${this.accountService.token}` },
      }
    );
  }

  deleteExpense(input: { id: number }) {
    return this.http.delete<expenseEntity>(`${mainBackendUrl}/api/expenses`, {
      headers: {
        Authorization: `Bearer ${this.accountService.token}`,
      },
      body: input,
    });
  }

  getExpenses(input: { id: number }) {
    return this.http.get<IPaginatedData<expenseEntity[]>>(
      `${mainBackendUrl}/api/expenses/${input.id}`,
      {
        headers: {
          Authorization: `Bearer ${this.accountService.token}`,
        },
      }
    );
  }
}
