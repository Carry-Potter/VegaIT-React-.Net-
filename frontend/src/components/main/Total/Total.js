import { useSelector } from 'react-redux'
import React from 'react';
import '../../App.css'

const Total = () => {
    
    const todos = useSelector((state)=> 
        state.todos);

    let totalHours = 0;

    for (let todo of todos) {
        totalHours += todo.hours
    }

    return (
        <div className="total align-right">
			<label htmlFor="" className="total-label">Total:</label>
			<input className="total-input" type="text" value={totalHours} readOnly/>
		</div>
    )
}

export default Total