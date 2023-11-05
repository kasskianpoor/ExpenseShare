import { userAccountDetailEntity } from './userAccountDetail-entity';

export type userEntity = {
  id: number;
  userName: string;
  email: string;
  userAccountDetail: userAccountDetailEntity;
  createdAt: Date;
};
