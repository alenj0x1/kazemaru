import ITag from './ITag';

export default interface INote {
  noteid: string;
  title: string;
  content: string;
  projectId: string | null;
  taskId: string | null;
  tags: ITag[];
  createdAt: string;
  updatedAt: string;
}
