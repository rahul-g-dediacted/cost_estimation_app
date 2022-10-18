export const INCREMENT = 'INCREMENT';
export const DECREMENT = 'DECREMENT';
export const RESET = 'RESET';
export const PERCENT = 'PERCENT';
export const COMPAIR = 'COMPAIR';

export function increaseCount() {
  return { type: INCREMENT };
}

export function decreaseCount() {
  return { type: DECREMENT };
}

export function resetCount() {
  return { type: RESET };
}

export function compair() {
  return { type: COMPAIR };
}
