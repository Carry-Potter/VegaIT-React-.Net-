import React, { useEffect, useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { getTimesheetAsync } from "../../../redux/timsheetSlice";

import Abc from "./abc/abc";
import ClientNames from "./clientNames/ClientNames";
import PageNumber from "../pageNumber/PageNumber";
import CreateClient from "./createClient/CreateClient";

const Client = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getTimesheetAsync());
  }, [dispatch]);

  const clients = useSelector((state) => state.timesheet);

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
            <CreateClient />
          </div>
          <Abc />
          <ClientNames />
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

export default Client;
