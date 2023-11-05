export type GroupMemberCreateInput = {
  userEmail: string;
  groupId: number;
};

export type GroupMemberDeleteInput = {
  userId: number;
  groupId: number;
};
