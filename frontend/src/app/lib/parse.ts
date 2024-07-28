export function getProjectStatus(status: number) {
  switch (status) {
    case 1:
      return {
        classes: 'bg-red-900/60 text-red-400 border-2 border-red-400/20 px-2 py-1 self-start',
        name: 'Unstarted'
      }
    case 2:
      return {
        classes: 'bg-blue-900/60 text-blue-400 border-2 border-blue-400/20 px-2 py-1 self-start',
        name: 'Starting'
      }
    case 3:
      return {
        classes: 'bg-orange-900/60 text-orange-400 border-2 border-orange-400/20 px-2 py-1 self-start',
        name: 'In progress'
      }
    case 4:
      return {
        classes: 'bg-green-900/60 text-green-400 border-2 border-green-400/20 px-2 py-1 self-start',
        name: 'Ended'
      }
    default:
      return {
        classes: 'bg-gray-600/60 text-gray-400 border-2 border-gray-400/20 px-2 py-1 self-start',
        name: 'Unknown'
      }
  }
}