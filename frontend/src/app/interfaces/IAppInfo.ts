import IProjectStatus from './IProjectStatus';
import ITag from './ITag';
import ITaskStatus from './ITaskStatus';

export default interface IAppInfo {
  tags: ITag[];
  projectStatuses: IProjectStatus[];
  taskStatuses: ITaskStatus[];
}
