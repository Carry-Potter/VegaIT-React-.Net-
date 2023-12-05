import React, { useEffect }  from 'react'
import { useSelector, useDispatch } from "react-redux";
import { getCategoryAsyn } from '../../../../redux/timsheetSlice';
import Categories from './categories/categories';

const CategoryName = () => {
    const dispatch = useDispatch();

    useEffect(() => {
      dispatch(getCategoryAsyn([]));
    }, [dispatch]);
  
    const categories = useSelector((state) => state.timesheet);
  
    console.log(categories);
  
    return (
      <div class="accordion-wrap clients">
        {categories.map((category) => (
          <div key={category.id}>
            <Categories
              names={category.name}
             
            />
          </div>
        ))}
      </div>
    );
  };
export default CategoryName
