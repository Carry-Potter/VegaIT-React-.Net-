import { configureStore} from '@reduxjs/toolkit';
import timesheetReducer from './timsheetSlice';

export default configureStore({
    reducer: {
        timesheet: timesheetReducer,

    }
})