import {createSlice, createAsyncThunk } from "@reduxjs/toolkit"

export const getTimesheetAsync = createAsyncThunk('timesheets/getTimesheetsAsync',
async (payload) => {
    const response = await fetch(`https://localhost:5001/api/client/page/1`); 
    if(response.ok) { 
        const timesheets = await response.json();
        
        return { timesheets }
    }
})


export const getTimesheetAsyncc = createAsyncThunk('timesheets/getTimesheetsAsync',
async (payload) => {
    const response = await fetch(`https://localhost:5001/api/client/page/${payload.id}`); 
    if(response.ok) { 
        const timesheets = await response.json();
        
        return { timesheets }
    }
})
export const getTeamMemberAsyn = createAsyncThunk('timesheets/getTimesheetsAsync',
async (payload) => {
    const response = await fetch(`https://localhost:5001/api/teammember`); 
    if(response.ok) { 
        const timesheets = await response.json();
        
        return { timesheets }
    }
})
export const getCategoryAsyn = createAsyncThunk('timesheets/getTimesheetsAsync',
async (payload) => {
    const response = await fetch(`https://localhost:5001/api/category`); 
    if(response.ok) { 
        const timesheets = await response.json();
        
        return { timesheets }
    }
})


export const getProjectAsyn = createAsyncThunk('timesheets/getTimesheetsAsync',
async (payload) => {
    const response = await fetch(`https://localhost:5001/api/project`); 
    if(response.ok) { 
        const timesheets = await response.json();
        
        return { timesheets }
    }
})

const timesheetSlice = createSlice ({
    name: "timesheets",
    initialState: [],
    reducers: {

    },
    extraReducers: {
        [getTimesheetAsync.pending]: (state, action)=> {
            console.log('peding...')
        },
        [getTimesheetAsync.fulfilled]: (state, action ) => {
            console.log('succesfully...')
            let timesheet = []
            for (let c of action.payload.timesheets) {
                timesheet.push(c)
            }
            return timesheet
        },
        [getTimesheetAsyncc.pending]: (state, action)=> {
            console.log('peding...')
        },
        [getTimesheetAsyncc.fulfilled]: (state, action ) => {
            console.log('succesfully...')
            let timesheet = []
            for (let c of action.payload.timesheets) {
                timesheet.push(c)
            }
            return timesheet
        },
        [getCategoryAsyn.pending]: (state, action)=> {
            console.log('peding...')
        },
        [getCategoryAsyn.fulfilled]: (state, action ) => {
            console.log('succesfully...')
            let timesheet = []
            for (let c of action.payload.timesheets) {
                timesheet.push(c)
            }
            return timesheet
        },
        [getTeamMemberAsyn.pending]: (state, action)=> {
            console.log('peding...')
        },
        [getTeamMemberAsyn.fulfilled]: (state, action ) => {
            console.log('succesfully...')
            let timesheet = []
            for (let c of action.payload.timesheets) {
                timesheet.push(c)
            }
            return timesheet
        },
        [getProjectAsyn.pending]: (state, action)=> {
            console.log('peding...')
        },
        [getProjectAsyn.fulfilled]: (state, action ) => {
            console.log('succesfully...')
            let timesheet = []
            for (let c of action.payload.timesheets) {
                timesheet.push(c)
            }
            return timesheet
        },
    }
})

export default timesheetSlice.reducer