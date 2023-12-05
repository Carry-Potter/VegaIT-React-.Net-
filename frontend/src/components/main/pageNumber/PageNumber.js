import React from "react";
import { useDispatch } from 'react-redux';
import { getTimesheetAsync, getTimesheetAsyncc } from "../../../redux/timsheetSlice";

const PageNumber = ({id}) => {
	
	const dispatch = useDispatch();

	const handlePageClick = () => {
		dispatch(getTimesheetAsyncc({id}))
	}

    return (			
		<a onClick={handlePageClick} >{id}</a>
    )
}

export default PageNumber