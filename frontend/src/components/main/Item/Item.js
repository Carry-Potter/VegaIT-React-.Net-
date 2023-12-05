import { deleteTodoAsync  } from '../../../redux/todoSlice';
import { useDispatch } from 'react-redux';
import '../../App.css'

const Item = ({id, title, hours}) => {
    const dispatch = useDispatch();

    const handleDeleteClick = () => {
		dispatch(deleteTodoAsync({id}))
	}

    return (
        <div className="item-row">
            <div className="check-flag">
                <span className="small-text-label">Title</span>
                <span className="small-text-label hours">Hours</span>
                <span className="check-flag-label" key="{title}">{title}</span>
                <span className="hours-box" key="{hours}">{hours}</span> 
            </div>
            <button className='btnn btn-danger' onClick={handleDeleteClick}>Delete</button>
    </div>
    )
}

export default Item