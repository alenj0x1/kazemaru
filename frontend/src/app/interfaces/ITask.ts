import ITaskStatus from './ITaskStatus';

export default interface ITask {
  taskId: string;
  projectId: string;
  name: string;
  description: string | null;
  status: ITaskStatus;
  createdAt: string;
  updateAt: string;
}
