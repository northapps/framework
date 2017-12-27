﻿
import * as React from 'react'
import { Modal, ModalHeader, ModalBody } from 'reactstrap'
import * as Finder from '../Finder'
import { openModal, IModalProps } from '../Modals';
import { ResultTable, FindOptions, FindMode, FilterOption, QueryDescription, ResultRow, ModalFindOptions } from '../FindOptions'
import { SearchMessage, JavascriptMessage, Lite, Entity } from '../Signum.Entities'
import { getQueryNiceName } from '../Reflection'
import SearchControl, { SearchControlProps} from './SearchControl'


interface SearchModalProps extends React.Props<SearchModal>, IModalProps {
    findOptions: FindOptions;
    findMode: FindMode;
    isMany: boolean;
    title?: string;

    searchControlProps?: Partial<SearchControlProps>;
}

export default class SearchModal extends React.Component<SearchModalProps, { show: boolean; }>  {

    constructor(props: SearchModalProps) {
        super(props);

        this.state = { show: true };
    }

    selectedRows: ResultRow[] = [];
    okPressed: boolean;

    handleSelectionChanged = (selected: ResultRow[]) => {
        this.selectedRows = selected;
        this.forceUpdate();
    }

    handleOkClicked = () => {
        this.okPressed = true;
        this.setState({ show: false });
    }

    handleCancelClicked = () => {
        this.okPressed = false;
        this.setState({ show: false });
    }

    handleOnExited = () => {
        this.props.onExited!(this.okPressed ? this.selectedRows : undefined);
    }

    handleDoubleClick = (e: React.MouseEvent<any>, row: ResultRow) => {
        e.preventDefault();
        this.selectedRows = [row];
        this.okPressed = true;
        this.setState({ show: false });
    }

    searchControl: SearchControl;

    render() {

        const okEnabled = this.props.isMany ? this.selectedRows.length > 0 : this.selectedRows.length == 1;

        return (
            <Modal size="lg" isOpen={this.state.show} onExit={this.handleOnExited}>
                <ModalHeader>
                    { this.props.findMode == "Find" &&
                        <div className="btn-toolbar pull-right flip">
                            <button className ="btn btn-primary sf-entity-button sf-close-button sf-ok-button" disabled={!okEnabled} onClick={this.handleOkClicked}>
                                {JavascriptMessage.ok.niceToString() }
                            </button>

                            <button className ="btn btn-default sf-entity-button sf-close-button sf-cancel-button" onClick={this.handleCancelClicked}>{JavascriptMessage.cancel.niceToString() }</button>
                        </div>}
                    <h4>
                        <span className="sf-entity-title"> {this.props.title}</span>&nbsp;
                        <a className="sf-popup-fullscreen pointer" onMouseUp={(e) => this.searchControl.handleFullScreenClick(e)}>
                            <span className="fa fa-external-link"></span>
                        </a>
                    </h4>
                </ModalHeader>

                <ModalBody>
                    <SearchControl
                        hideFullScreenButton={true}
                        throwIfNotFindable={true}
                        ref={e => this.searchControl = e!}
                        findOptions={this.props.findOptions}
                        onSelectionChanged={this.handleSelectionChanged}
                        largeToolbarButtons={true}
                        onDoubleClick={this.props.findMode == "Find" ? this.handleDoubleClick : undefined}
                        {...this.props.searchControlProps}
                        />
                </ModalBody>
            </Modal>
        );
    }

    static open(findOptions: FindOptions, modalOptions?: ModalFindOptions): Promise<ResultRow | undefined> {

        return openModal<ResultRow[]>(<SearchModal
            findOptions={findOptions}
            findMode={"Find"}
            isMany={false}
            title={modalOptions && modalOptions.title || getQueryNiceName(findOptions.queryName)}
            searchControlProps={modalOptions && modalOptions.searchControlProps}
        />)
            .then(a => a ? a[0] : undefined);
    }

    static openMany(findOptions: FindOptions, modalOptions?: ModalFindOptions): Promise<ResultRow[] | undefined> {

        return openModal<ResultRow[]>(<SearchModal findOptions={findOptions}
            findMode={"Find"}
            isMany={true}
            title={modalOptions && modalOptions.title || getQueryNiceName(findOptions.queryName)}
            searchControlProps={modalOptions && modalOptions.searchControlProps}
        />);
    }

    static explore(findOptions: FindOptions, modalOptions?: ModalFindOptions): Promise<void> {

        return openModal<void>(<SearchModal findOptions={findOptions}
            findMode={"Explore"}
            isMany={true}
            title={modalOptions && modalOptions.title || getQueryNiceName(findOptions.queryName) } />);
    }
}



