import {
  INCREMENT,
  DECREMENT,
  RESET,
  PERCENT,
  COMPAIR,
} from '../actions/index';

const INITIAL_STATE = {
  count: 0,
  percent: '0 %',
  history: [],
  compairDialog: false,
};

function handleChange(state, change) {
  const { count, history } = state;
  return {
    count: count + change,
    history: [count + change, ...history],
  };
}

function handleChangePercent(state, change) {
  return {
    percent: change,
  };
}

export default function counter(state = INITIAL_STATE, action) {
  const { count, history } = state;
  switch (action.type) {
    case INCREMENT:
      return handleChange(state, 1);
    case DECREMENT:
      return handleChange(state, -1);
    case RESET:
      return INITIAL_STATE;
    case PERCENT:
      return handleChangePercent(state, action.payload);
    case COMPAIR:
      return { compairDialog: action.payload };
    default:
      return state;
  }
}
