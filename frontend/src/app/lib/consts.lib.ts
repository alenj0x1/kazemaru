import { IAnimationsState } from '../interfaces/app/animations-state.interface';

export const DEFAULT_STATE_ANIMATIONS: IAnimationsState = {
  projectThumbHeader: {
    displayName: 'Project Thumb Header',
    description: "In /projects add a zoom effect to each project's banner",
    state: false,
  },
  projectThumbHoverIncrease: {
    displayName: 'Project Thumb Hover Increase',
    description: "In /projects, when hovering over a project thumbnail, the size increases downwards.",
    state: false,
  },
  projectBlur: {
    displayName: 'Project Blur',
    description: "When viewing a project behind the banner apply a blur effect similar to the banner",
    state: false,
  },
};
