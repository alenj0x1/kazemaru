export default interface INoteUpdateRequest {
  noteId: string;
  title: string | null;
  content: string | null;
  projectId: string | null;
  taskId: string | null;
}
