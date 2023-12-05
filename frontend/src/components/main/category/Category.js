import React, { useEffect, useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { getCategoryAsyn } from "../../../redux/timsheetSlice";

import Abc from "../client/abc/abc";
import CategoryName from "./categoryName/CategoryName";
import PageNumber from "../pageNumber/PageNumber";


const Category = () => {
    const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getCategoryAsyn());
  }, [dispatch]);

  const categories = useSelector((state) => state.timesheet);

  const [isActive, setActive] = useState("false");

  const ToggleClass = () => {
    setActive(!isActive);
  };

  return (
    <div class="container">
      <div class="wrapper">
        <section class="content">
          <h2>
            <i class="ico clients"></i>Clients
          </h2>
          <div class="grey-box-wrap reports">
            <a href="#" onClick={ToggleClass} class="link new-member-popup">
              Create new client
            </a>
            <div class="search-page">
              <input type="search" name="search-clients" class="in-search" />
            </div>
          </div>
          <div className={isActive ? "new-member-wrap" : "new-member-wrap2"}>
           
          </div>
          <Abc />
          <CategoryName />
          <div className="pagination">
            <ul>
              {Array.from(Array(3), (e, i) => {
                return (
                  <li>
                    <PageNumber id={i + 1} />
                  </li>
                );
              })}
            </ul>
          </div>
        </section>
      </div>
    </div>
  );
};

export default Category