using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * デバッグ用。
 * クエリとVisitorの関係を表示する。
 * ドキュメントがあまりに少ないせいでそれすらわからない・・・
 *  http://msdn.microsoft.com/ja-jp/library/microsoft.sqlserver.transactsql.scriptdom.tsqlfragmentvisitor.explicitvisit.aspx
 */
namespace RuleChecker.SqlCheck
{
    class SqlParserDebug
    {
        public readonly static string TEST_FILE_NAME = "tsql_debug-in.sql";
        public readonly static Encoding DEFAULT_ENCODING = Encoding.GetEncoding("Shift_JIS");

        public void RunDebug()
        {
            //出力が多すぎてコンソールでは荷が重いのでファイルに出力する
            //ファイルは各自作る。
            string fileName = "tsql_debug-out.txt";
            using(StreamWriter writer = new StreamWriter(fileName))
            {
                Console.SetOut(writer);
                
                TSqlParser parser = new TSql100Parser(false);
                
                IList<ParseError> errors;
                StreamReader reader = new StreamReader(TEST_FILE_NAME, DEFAULT_ENCODING);
                
                TSqlFragment parsed = parser.Parse(reader, out errors);
                
                if (errors.Count != 0)
                {
                    throw new Exception("パース失敗");
                }
                
                parsed.Accept(new DebugSQLVisitor());

                Console.WriteLine("End ");

                IList<TSqlParserToken> tokenList = parsed.ScriptTokenStream;
                foreach (TSqlParserToken token in tokenList)
                {
                    Console.Write(token.Text);
                }
            }
        }
    }
    /*
     * デバッグ用のVisitorクラス。
     * 以下は参照に入っていなかったので削除している
     * CreateSelectiveXmlIndexStatement
     * SelectiveXmlIndexPromotedPath
     * 
     * なぜ入っていないのかは不明。バージョンのせいだと思うが
     */
    internal class DebugSQLVisitor : TSqlFragmentVisitor
    {
        private bool doVisitPrint = false;
        
        public override void ExplicitVisit(AddAlterFullTextIndexAction node)
        {
            Console.WriteLine("Start ExplicitVisit(AddAlterFullTextIndexAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AddAlterFullTextIndexAction)");
        }

        public override void ExplicitVisit(AddFileSpec node)
        {
            Console.WriteLine("Start ExplicitVisit(AddFileSpec)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AddFileSpec)");
        }

        public override void ExplicitVisit(AddMemberAlterRoleAction node)
        {
            Console.WriteLine("Start ExplicitVisit(AddMemberAlterRoleAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AddMemberAlterRoleAction)");
        }

        public override void ExplicitVisit(AddSearchPropertyListAction node)
        {
            Console.WriteLine("Start ExplicitVisit(AddSearchPropertyListAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AddSearchPropertyListAction)");
        }

        public override void ExplicitVisit(AddSignatureStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AddSignatureStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AddSignatureStatement)");
        }

        public override void ExplicitVisit(AdHocDataSource node)
        {
            Console.WriteLine("Start ExplicitVisit(AdHocDataSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AdHocDataSource)");
        }

        public override void ExplicitVisit(AdHocTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(AdHocTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AdHocTableReference)");
        }

        public override void ExplicitVisit(AlgorithmKeyOption node)
        {
            Console.WriteLine("Start ExplicitVisit(AlgorithmKeyOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlgorithmKeyOption)");
        }

        public override void ExplicitVisit(AlterApplicationRoleStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterApplicationRoleStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterApplicationRoleStatement)");
        }

        public override void ExplicitVisit(AlterAssemblyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterAssemblyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterAssemblyStatement)");
        }

        public override void ExplicitVisit(AlterAsymmetricKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterAsymmetricKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterAsymmetricKeyStatement)");
        }

        public override void ExplicitVisit(AlterAuthorizationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterAuthorizationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterAuthorizationStatement)");
        }

        public override void ExplicitVisit(AlterAvailabilityGroupAction node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterAvailabilityGroupAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterAvailabilityGroupAction)");
        }

        public override void ExplicitVisit(AlterAvailabilityGroupFailoverAction node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterAvailabilityGroupFailoverAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterAvailabilityGroupFailoverAction)");
        }

        public override void ExplicitVisit(AlterAvailabilityGroupFailoverOption node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterAvailabilityGroupFailoverOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterAvailabilityGroupFailoverOption)");
        }

        public override void ExplicitVisit(AlterAvailabilityGroupStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterAvailabilityGroupStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterAvailabilityGroupStatement)");
        }

        public override void ExplicitVisit(AlterBrokerPriorityStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterBrokerPriorityStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterBrokerPriorityStatement)");
        }

        public override void ExplicitVisit(AlterCertificateStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterCertificateStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterCertificateStatement)");
        }

        public override void ExplicitVisit(AlterColumnAlterFullTextIndexAction node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterColumnAlterFullTextIndexAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterColumnAlterFullTextIndexAction)");
        }

        public override void ExplicitVisit(AlterCreateEndpointStatementBase node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterCreateEndpointStatementBase)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterCreateEndpointStatementBase)");
        }

        public override void ExplicitVisit(AlterCreateServiceStatementBase node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterCreateServiceStatementBase)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterCreateServiceStatementBase)");
        }

        public override void ExplicitVisit(AlterCredentialStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterCredentialStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterCredentialStatement)");
        }

        public override void ExplicitVisit(AlterCryptographicProviderStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterCryptographicProviderStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterCryptographicProviderStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseAddFileGroupStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseAddFileGroupStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseAddFileGroupStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseAddFileStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseAddFileStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseAddFileStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseAuditSpecificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseAuditSpecificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseAuditSpecificationStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseCollateStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseCollateStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseCollateStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseEncryptionKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseEncryptionKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseEncryptionKeyStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseModifyFileGroupStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseModifyFileGroupStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseModifyFileGroupStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseModifyFileStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseModifyFileStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseModifyFileStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseModifyNameStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseModifyNameStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseModifyNameStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseRebuildLogStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseRebuildLogStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseRebuildLogStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseRemoveFileGroupStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseRemoveFileGroupStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseRemoveFileGroupStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseRemoveFileStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseRemoveFileStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseRemoveFileStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseSetStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseSetStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseSetStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseStatement)");
        }

        public override void ExplicitVisit(AlterDatabaseTermination node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterDatabaseTermination)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterDatabaseTermination)");
        }

        public override void ExplicitVisit(AlterEndpointStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterEndpointStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterEndpointStatement)");
        }

        public override void ExplicitVisit(AlterEventSessionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterEventSessionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterEventSessionStatement)");
        }

        public override void ExplicitVisit(AlterFederationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterFederationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterFederationStatement)");
        }

        public override void ExplicitVisit(AlterFullTextCatalogStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterFullTextCatalogStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterFullTextCatalogStatement)");
        }

        public override void ExplicitVisit(AlterFullTextIndexAction node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterFullTextIndexAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterFullTextIndexAction)");
        }

        public override void ExplicitVisit(AlterFullTextIndexStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterFullTextIndexStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterFullTextIndexStatement)");
        }

        public override void ExplicitVisit(AlterFullTextStopListStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterFullTextStopListStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterFullTextStopListStatement)");
        }

        public override void ExplicitVisit(AlterFunctionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterFunctionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterFunctionStatement)");
        }

        public override void ExplicitVisit(AlterIndexStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterIndexStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterIndexStatement)");
        }

        public override void ExplicitVisit(AlterLoginAddDropCredentialStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterLoginAddDropCredentialStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterLoginAddDropCredentialStatement)");
        }

        public override void ExplicitVisit(AlterLoginEnableDisableStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterLoginEnableDisableStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterLoginEnableDisableStatement)");
        }

        public override void ExplicitVisit(AlterLoginOptionsStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterLoginOptionsStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterLoginOptionsStatement)");
        }

        public override void ExplicitVisit(AlterLoginStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterLoginStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterLoginStatement)");
        }

        public override void ExplicitVisit(AlterMasterKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterMasterKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterMasterKeyStatement)");
        }

        public override void ExplicitVisit(AlterMessageTypeStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterMessageTypeStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterMessageTypeStatement)");
        }

        public override void ExplicitVisit(AlterPartitionFunctionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterPartitionFunctionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterPartitionFunctionStatement)");
        }

        public override void ExplicitVisit(AlterPartitionSchemeStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterPartitionSchemeStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterPartitionSchemeStatement)");
        }

        public override void ExplicitVisit(AlterProcedureStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterProcedureStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterProcedureStatement)");
        }

        public override void ExplicitVisit(AlterQueueStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterQueueStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterQueueStatement)");
        }

        public override void ExplicitVisit(AlterRemoteServiceBindingStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterRemoteServiceBindingStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterRemoteServiceBindingStatement)");
        }

        public override void ExplicitVisit(AlterResourceGovernorStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterResourceGovernorStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterResourceGovernorStatement)");
        }

        public override void ExplicitVisit(AlterResourcePoolStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterResourcePoolStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterResourcePoolStatement)");
        }

        public override void ExplicitVisit(AlterRoleAction node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterRoleAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterRoleAction)");
        }

        public override void ExplicitVisit(AlterRoleStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterRoleStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterRoleStatement)");
        }

        public override void ExplicitVisit(AlterRouteStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterRouteStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterRouteStatement)");
        }

        public override void ExplicitVisit(AlterSchemaStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterSchemaStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterSchemaStatement)");
        }

        public override void ExplicitVisit(AlterSearchPropertyListStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterSearchPropertyListStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterSearchPropertyListStatement)");
        }

        public override void ExplicitVisit(AlterSequenceStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterSequenceStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterSequenceStatement)");
        }

        public override void ExplicitVisit(AlterServerAuditSpecificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterServerAuditSpecificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterServerAuditSpecificationStatement)");
        }

        public override void ExplicitVisit(AlterServerAuditStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterServerAuditStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterServerAuditStatement)");
        }

        public override void ExplicitVisit(AlterServerConfigurationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterServerConfigurationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterServerConfigurationStatement)");
        }

        public override void ExplicitVisit(AlterServerRoleStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterServerRoleStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterServerRoleStatement)");
        }

        public override void ExplicitVisit(AlterServiceMasterKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterServiceMasterKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterServiceMasterKeyStatement)");
        }

        public override void ExplicitVisit(AlterServiceStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterServiceStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterServiceStatement)");
        }

        public override void ExplicitVisit(AlterSymmetricKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterSymmetricKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterSymmetricKeyStatement)");
        }

        public override void ExplicitVisit(AlterTableAddTableElementStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterTableAddTableElementStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterTableAddTableElementStatement)");
        }

        public override void ExplicitVisit(AlterTableAlterColumnStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterTableAlterColumnStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterTableAlterColumnStatement)");
        }

        public override void ExplicitVisit(AlterTableChangeTrackingModificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterTableChangeTrackingModificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterTableChangeTrackingModificationStatement)");
        }

        public override void ExplicitVisit(AlterTableConstraintModificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterTableConstraintModificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterTableConstraintModificationStatement)");
        }

        public override void ExplicitVisit(AlterTableDropTableElement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterTableDropTableElement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterTableDropTableElement)");
        }

        public override void ExplicitVisit(AlterTableDropTableElementStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterTableDropTableElementStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterTableDropTableElementStatement)");
        }

        public override void ExplicitVisit(AlterTableFileTableNamespaceStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterTableFileTableNamespaceStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterTableFileTableNamespaceStatement)");
        }

        public override void ExplicitVisit(AlterTableRebuildStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterTableRebuildStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterTableRebuildStatement)");
        }

        public override void ExplicitVisit(AlterTableSetStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterTableSetStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterTableSetStatement)");
        }

        public override void ExplicitVisit(AlterTableStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterTableStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterTableStatement)");
        }

        public override void ExplicitVisit(AlterTableSwitchStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterTableSwitchStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterTableSwitchStatement)");
        }

        public override void ExplicitVisit(AlterTableTriggerModificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterTableTriggerModificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterTableTriggerModificationStatement)");
        }

        public override void ExplicitVisit(AlterTriggerStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterTriggerStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterTriggerStatement)");
        }

        public override void ExplicitVisit(AlterUserStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterUserStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterUserStatement)");
        }

        public override void ExplicitVisit(AlterViewStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterViewStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterViewStatement)");
        }

        public override void ExplicitVisit(AlterWorkloadGroupStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterWorkloadGroupStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterWorkloadGroupStatement)");
        }

        public override void ExplicitVisit(AlterXmlSchemaCollectionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AlterXmlSchemaCollectionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AlterXmlSchemaCollectionStatement)");
        }

        public override void ExplicitVisit(ApplicationRoleOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ApplicationRoleOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ApplicationRoleOption)");
        }

        public override void ExplicitVisit(ApplicationRoleStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(ApplicationRoleStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ApplicationRoleStatement)");
        }

        public override void ExplicitVisit(AssemblyEncryptionSource node)
        {
            Console.WriteLine("Start ExplicitVisit(AssemblyEncryptionSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AssemblyEncryptionSource)");
        }

        public override void ExplicitVisit(AssemblyName node)
        {
            Console.WriteLine("Start ExplicitVisit(AssemblyName)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AssemblyName)");
        }

        public override void ExplicitVisit(AssemblyOption node)
        {
            Console.WriteLine("Start ExplicitVisit(AssemblyOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AssemblyOption)");
        }

        public override void ExplicitVisit(AssemblyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AssemblyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AssemblyStatement)");
        }

        public override void ExplicitVisit(AssignmentSetClause node)
        {
            Console.WriteLine("Start ExplicitVisit(AssignmentSetClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AssignmentSetClause)");
        }

        public override void ExplicitVisit(AsymmetricKeyCreateLoginSource node)
        {
            Console.WriteLine("Start ExplicitVisit(AsymmetricKeyCreateLoginSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AsymmetricKeyCreateLoginSource)");
        }

        public override void ExplicitVisit(AuditActionGroupReference node)
        {
            Console.WriteLine("Start ExplicitVisit(AuditActionGroupReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AuditActionGroupReference)");
        }

        public override void ExplicitVisit(AuditActionSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(AuditActionSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AuditActionSpecification)");
        }

        public override void ExplicitVisit(AuditGuidAuditOption node)
        {
            Console.WriteLine("Start ExplicitVisit(AuditGuidAuditOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AuditGuidAuditOption)");
        }

        public override void ExplicitVisit(AuditOption node)
        {
            Console.WriteLine("Start ExplicitVisit(AuditOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AuditOption)");
        }

        public override void ExplicitVisit(AuditSpecificationDetail node)
        {
            Console.WriteLine("Start ExplicitVisit(AuditSpecificationDetail)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AuditSpecificationDetail)");
        }

        public override void ExplicitVisit(AuditSpecificationPart node)
        {
            Console.WriteLine("Start ExplicitVisit(AuditSpecificationPart)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AuditSpecificationPart)");
        }

        public override void ExplicitVisit(AuditSpecificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AuditSpecificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AuditSpecificationStatement)");
        }

        public override void ExplicitVisit(AuditTarget node)
        {
            Console.WriteLine("Start ExplicitVisit(AuditTarget)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AuditTarget)");
        }

        public override void ExplicitVisit(AuditTargetOption node)
        {
            Console.WriteLine("Start ExplicitVisit(AuditTargetOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AuditTargetOption)");
        }

        public override void ExplicitVisit(AuthenticationEndpointProtocolOption node)
        {
            Console.WriteLine("Start ExplicitVisit(AuthenticationEndpointProtocolOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AuthenticationEndpointProtocolOption)");
        }

        public override void ExplicitVisit(AuthenticationPayloadOption node)
        {
            Console.WriteLine("Start ExplicitVisit(AuthenticationPayloadOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AuthenticationPayloadOption)");
        }

        public override void ExplicitVisit(AutoCleanupChangeTrackingOptionDetail node)
        {
            Console.WriteLine("Start ExplicitVisit(AutoCleanupChangeTrackingOptionDetail)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AutoCleanupChangeTrackingOptionDetail)");
        }

        public override void ExplicitVisit(AvailabilityGroupOption node)
        {
            Console.WriteLine("Start ExplicitVisit(AvailabilityGroupOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AvailabilityGroupOption)");
        }

        public override void ExplicitVisit(AvailabilityGroupStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(AvailabilityGroupStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AvailabilityGroupStatement)");
        }

        public override void ExplicitVisit(AvailabilityModeReplicaOption node)
        {
            Console.WriteLine("Start ExplicitVisit(AvailabilityModeReplicaOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AvailabilityModeReplicaOption)");
        }

        public override void ExplicitVisit(AvailabilityReplica node)
        {
            Console.WriteLine("Start ExplicitVisit(AvailabilityReplica)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AvailabilityReplica)");
        }

        public override void ExplicitVisit(AvailabilityReplicaOption node)
        {
            Console.WriteLine("Start ExplicitVisit(AvailabilityReplicaOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(AvailabilityReplicaOption)");
        }

        public override void ExplicitVisit(BackupCertificateStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(BackupCertificateStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BackupCertificateStatement)");
        }

        public override void ExplicitVisit(BackupDatabaseStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(BackupDatabaseStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BackupDatabaseStatement)");
        }

        public override void ExplicitVisit(BackupMasterKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(BackupMasterKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BackupMasterKeyStatement)");
        }

        public override void ExplicitVisit(BackupOption node)
        {
            Console.WriteLine("Start ExplicitVisit(BackupOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BackupOption)");
        }

        public override void ExplicitVisit(BackupRestoreFileInfo node)
        {
            Console.WriteLine("Start ExplicitVisit(BackupRestoreFileInfo)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BackupRestoreFileInfo)");
        }

        public override void ExplicitVisit(BackupRestoreMasterKeyStatementBase node)
        {
            Console.WriteLine("Start ExplicitVisit(BackupRestoreMasterKeyStatementBase)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BackupRestoreMasterKeyStatementBase)");
        }

        public override void ExplicitVisit(BackupServiceMasterKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(BackupServiceMasterKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BackupServiceMasterKeyStatement)");
        }

        public override void ExplicitVisit(BackupStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(BackupStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BackupStatement)");
        }

        public override void ExplicitVisit(BackupTransactionLogStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(BackupTransactionLogStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BackupTransactionLogStatement)");
        }

        public override void ExplicitVisit(BackwardsCompatibleDropIndexClause node)
        {
            Console.WriteLine("Start ExplicitVisit(BackwardsCompatibleDropIndexClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BackwardsCompatibleDropIndexClause)");
        }

        public override void ExplicitVisit(BeginConversationTimerStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(BeginConversationTimerStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BeginConversationTimerStatement)");
        }

        public override void ExplicitVisit(BeginDialogStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(BeginDialogStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BeginDialogStatement)");
        }

        public override void ExplicitVisit(BeginEndBlockStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(BeginEndBlockStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BeginEndBlockStatement)");
        }

        public override void ExplicitVisit(BeginTransactionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(BeginTransactionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BeginTransactionStatement)");
        }

        public override void ExplicitVisit(BinaryExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(BinaryExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BinaryExpression)");
        }

        public override void ExplicitVisit(BinaryLiteral node)
        {
            Console.WriteLine("Start ExplicitVisit(BinaryLiteral)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BinaryLiteral)");
        }

        public override void ExplicitVisit(BinaryQueryExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(BinaryQueryExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BinaryQueryExpression)");
        }

        public override void ExplicitVisit(BooleanBinaryExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(BooleanBinaryExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BooleanBinaryExpression)");
        }

        public override void ExplicitVisit(BooleanComparisonExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(BooleanComparisonExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BooleanComparisonExpression)");
        }

        public override void ExplicitVisit(BooleanExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(BooleanExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BooleanExpression)");
        }

        public override void ExplicitVisit(BooleanExpressionSnippet node)
        {
            Console.WriteLine("Start ExplicitVisit(BooleanExpressionSnippet)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BooleanExpressionSnippet)");
        }

        public override void ExplicitVisit(BooleanIsNullExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(BooleanIsNullExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BooleanIsNullExpression)");
        }

        public override void ExplicitVisit(BooleanNotExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(BooleanNotExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BooleanNotExpression)");
        }

        public override void ExplicitVisit(BooleanParenthesisExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(BooleanParenthesisExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BooleanParenthesisExpression)");
        }

        public override void ExplicitVisit(BooleanTernaryExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(BooleanTernaryExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BooleanTernaryExpression)");
        }

        public override void ExplicitVisit(BoundingBoxParameter node)
        {
            Console.WriteLine("Start ExplicitVisit(BoundingBoxParameter)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BoundingBoxParameter)");
        }

        public override void ExplicitVisit(BoundingBoxSpatialIndexOption node)
        {
            Console.WriteLine("Start ExplicitVisit(BoundingBoxSpatialIndexOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BoundingBoxSpatialIndexOption)");
        }

        public override void ExplicitVisit(BreakStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(BreakStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BreakStatement)");
        }

        public override void ExplicitVisit(BrokerPriorityParameter node)
        {
            Console.WriteLine("Start ExplicitVisit(BrokerPriorityParameter)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BrokerPriorityParameter)");
        }

        public override void ExplicitVisit(BrokerPriorityStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(BrokerPriorityStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BrokerPriorityStatement)");
        }

        public override void ExplicitVisit(BrowseForClause node)
        {
            Console.WriteLine("Start ExplicitVisit(BrowseForClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BrowseForClause)");
        }

        public override void ExplicitVisit(BuiltInFunctionTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(BuiltInFunctionTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BuiltInFunctionTableReference)");
        }

        public override void ExplicitVisit(BulkInsertBase node)
        {
            Console.WriteLine("Start ExplicitVisit(BulkInsertBase)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BulkInsertBase)");
        }

        public override void ExplicitVisit(BulkInsertOption node)
        {
            Console.WriteLine("Start ExplicitVisit(BulkInsertOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BulkInsertOption)");
        }

        public override void ExplicitVisit(BulkInsertStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(BulkInsertStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BulkInsertStatement)");
        }

        public override void ExplicitVisit(BulkOpenRowset node)
        {
            Console.WriteLine("Start ExplicitVisit(BulkOpenRowset)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(BulkOpenRowset)");
        }

        public override void ExplicitVisit(CallTarget node)
        {
            Console.WriteLine("Start ExplicitVisit(CallTarget)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CallTarget)");
        }

        public override void ExplicitVisit(CaseExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(CaseExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CaseExpression)");
        }

        public override void ExplicitVisit(CastCall node)
        {
            Console.WriteLine("Start ExplicitVisit(CastCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CastCall)");
        }

        public override void ExplicitVisit(CellsPerObjectSpatialIndexOption node)
        {
            Console.WriteLine("Start ExplicitVisit(CellsPerObjectSpatialIndexOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CellsPerObjectSpatialIndexOption)");
        }

        public override void ExplicitVisit(CertificateCreateLoginSource node)
        {
            Console.WriteLine("Start ExplicitVisit(CertificateCreateLoginSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CertificateCreateLoginSource)");
        }

        public override void ExplicitVisit(CertificateOption node)
        {
            Console.WriteLine("Start ExplicitVisit(CertificateOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CertificateOption)");
        }

        public override void ExplicitVisit(CertificateStatementBase node)
        {
            Console.WriteLine("Start ExplicitVisit(CertificateStatementBase)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CertificateStatementBase)");
        }

        public override void ExplicitVisit(ChangeRetentionChangeTrackingOptionDetail node)
        {
            Console.WriteLine("Start ExplicitVisit(ChangeRetentionChangeTrackingOptionDetail)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ChangeRetentionChangeTrackingOptionDetail)");
        }

        public override void ExplicitVisit(ChangeTableChangesTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(ChangeTableChangesTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ChangeTableChangesTableReference)");
        }

        public override void ExplicitVisit(ChangeTableVersionTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(ChangeTableVersionTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ChangeTableVersionTableReference)");
        }

        public override void ExplicitVisit(ChangeTrackingDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ChangeTrackingDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ChangeTrackingDatabaseOption)");
        }

        public override void ExplicitVisit(ChangeTrackingFullTextIndexOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ChangeTrackingFullTextIndexOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ChangeTrackingFullTextIndexOption)");
        }

        public override void ExplicitVisit(ChangeTrackingOptionDetail node)
        {
            Console.WriteLine("Start ExplicitVisit(ChangeTrackingOptionDetail)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ChangeTrackingOptionDetail)");
        }

        public override void ExplicitVisit(CharacterSetPayloadOption node)
        {
            Console.WriteLine("Start ExplicitVisit(CharacterSetPayloadOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CharacterSetPayloadOption)");
        }

        public override void ExplicitVisit(CheckConstraintDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(CheckConstraintDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CheckConstraintDefinition)");
        }

        public override void ExplicitVisit(CheckpointStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CheckpointStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CheckpointStatement)");
        }

        public override void ExplicitVisit(ChildObjectName node)
        {
            Console.WriteLine("Start ExplicitVisit(ChildObjectName)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ChildObjectName)");
        }

        public override void ExplicitVisit(CloseCursorStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CloseCursorStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CloseCursorStatement)");
        }

        public override void ExplicitVisit(CloseMasterKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CloseMasterKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CloseMasterKeyStatement)");
        }

        public override void ExplicitVisit(CloseSymmetricKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CloseSymmetricKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CloseSymmetricKeyStatement)");
        }

        public override void ExplicitVisit(CoalesceExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(CoalesceExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CoalesceExpression)");
        }

        public override void ExplicitVisit(ColumnDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(ColumnDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ColumnDefinition)");
        }

        public override void ExplicitVisit(ColumnDefinitionBase node)
        {
            Console.WriteLine("Start ExplicitVisit(ColumnDefinitionBase)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ColumnDefinitionBase)");
        }

        public override void ExplicitVisit(ColumnReferenceExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(ColumnReferenceExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ColumnReferenceExpression)");
        }

        public override void ExplicitVisit(ColumnStorageOptions node)
        {
            Console.WriteLine("Start ExplicitVisit(ColumnStorageOptions)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ColumnStorageOptions)");
        }

        public override void ExplicitVisit(ColumnWithSortOrder node)
        {
            Console.WriteLine("Start ExplicitVisit(ColumnWithSortOrder)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ColumnWithSortOrder)");
        }

        public override void ExplicitVisit(CommandSecurityElement80 node)
        {
            Console.WriteLine("Start ExplicitVisit(CommandSecurityElement80)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CommandSecurityElement80)");
        }

        public override void ExplicitVisit(CommitTransactionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CommitTransactionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CommitTransactionStatement)");
        }

        public override void ExplicitVisit(CommonTableExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(CommonTableExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CommonTableExpression)");
        }

        public override void ExplicitVisit(CompositeGroupingSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(CompositeGroupingSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CompositeGroupingSpecification)");
        }

        public override void ExplicitVisit(CompressionEndpointProtocolOption node)
        {
            Console.WriteLine("Start ExplicitVisit(CompressionEndpointProtocolOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CompressionEndpointProtocolOption)");
        }

        public override void ExplicitVisit(CompressionPartitionRange node)
        {
            Console.WriteLine("Start ExplicitVisit(CompressionPartitionRange)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CompressionPartitionRange)");
        }

        public override void ExplicitVisit(ComputeClause node)
        {
            Console.WriteLine("Start ExplicitVisit(ComputeClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ComputeClause)");
        }

        public override void ExplicitVisit(ComputeFunction node)
        {
            Console.WriteLine("Start ExplicitVisit(ComputeFunction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ComputeFunction)");
        }

        public override void ExplicitVisit(ConstraintDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(ConstraintDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ConstraintDefinition)");
        }

        public override void ExplicitVisit(ContainmentDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ContainmentDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ContainmentDatabaseOption)");
        }

        public override void ExplicitVisit(ContinueStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(ContinueStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ContinueStatement)");
        }

        public override void ExplicitVisit(ContractMessage node)
        {
            Console.WriteLine("Start ExplicitVisit(ContractMessage)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ContractMessage)");
        }

        public override void ExplicitVisit(ConvertCall node)
        {
            Console.WriteLine("Start ExplicitVisit(ConvertCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ConvertCall)");
        }

        public override void ExplicitVisit(CreateAggregateStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateAggregateStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateAggregateStatement)");
        }

        public override void ExplicitVisit(CreateApplicationRoleStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateApplicationRoleStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateApplicationRoleStatement)");
        }

        public override void ExplicitVisit(CreateAssemblyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateAssemblyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateAssemblyStatement)");
        }

        public override void ExplicitVisit(CreateAsymmetricKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateAsymmetricKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateAsymmetricKeyStatement)");
        }

        public override void ExplicitVisit(CreateAvailabilityGroupStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateAvailabilityGroupStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateAvailabilityGroupStatement)");
        }

        public override void ExplicitVisit(CreateBrokerPriorityStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateBrokerPriorityStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateBrokerPriorityStatement)");
        }

        public override void ExplicitVisit(CreateCertificateStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateCertificateStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateCertificateStatement)");
        }

        public override void ExplicitVisit(CreateColumnStoreIndexStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateColumnStoreIndexStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateColumnStoreIndexStatement)");
        }

        public override void ExplicitVisit(CreateContractStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateContractStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateContractStatement)");
        }

        public override void ExplicitVisit(CreateCredentialStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateCredentialStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateCredentialStatement)");
        }

        public override void ExplicitVisit(CreateCryptographicProviderStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateCryptographicProviderStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateCryptographicProviderStatement)");
        }

        public override void ExplicitVisit(CreateDatabaseAuditSpecificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateDatabaseAuditSpecificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateDatabaseAuditSpecificationStatement)");
        }

        public override void ExplicitVisit(CreateDatabaseEncryptionKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateDatabaseEncryptionKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateDatabaseEncryptionKeyStatement)");
        }

        public override void ExplicitVisit(CreateDatabaseStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateDatabaseStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateDatabaseStatement)");
        }

        public override void ExplicitVisit(CreateDefaultStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateDefaultStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateDefaultStatement)");
        }

        public override void ExplicitVisit(CreateEndpointStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateEndpointStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateEndpointStatement)");
        }

        public override void ExplicitVisit(CreateEventNotificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateEventNotificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateEventNotificationStatement)");
        }

        public override void ExplicitVisit(CreateEventSessionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateEventSessionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateEventSessionStatement)");
        }

        public override void ExplicitVisit(CreateFederationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateFederationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateFederationStatement)");
        }

        public override void ExplicitVisit(CreateFullTextCatalogStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateFullTextCatalogStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateFullTextCatalogStatement)");
        }

        public override void ExplicitVisit(CreateFullTextIndexStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateFullTextIndexStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateFullTextIndexStatement)");
        }

        public override void ExplicitVisit(CreateFullTextStopListStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateFullTextStopListStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateFullTextStopListStatement)");
        }

        public override void ExplicitVisit(CreateFunctionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateFunctionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateFunctionStatement)");
        }

        public override void ExplicitVisit(CreateIndexStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateIndexStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateIndexStatement)");
        }

        public override void ExplicitVisit(CreateLoginSource node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateLoginSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateLoginSource)");
        }

        public override void ExplicitVisit(CreateLoginStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateLoginStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateLoginStatement)");
        }

        public override void ExplicitVisit(CreateMasterKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateMasterKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateMasterKeyStatement)");
        }

        public override void ExplicitVisit(CreateMessageTypeStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateMessageTypeStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateMessageTypeStatement)");
        }

        public override void ExplicitVisit(CreatePartitionFunctionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreatePartitionFunctionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreatePartitionFunctionStatement)");
        }

        public override void ExplicitVisit(CreatePartitionSchemeStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreatePartitionSchemeStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreatePartitionSchemeStatement)");
        }

        public override void ExplicitVisit(CreateProcedureStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateProcedureStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateProcedureStatement)");
        }

        public override void ExplicitVisit(CreateQueueStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateQueueStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateQueueStatement)");
        }

        public override void ExplicitVisit(CreateRemoteServiceBindingStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateRemoteServiceBindingStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateRemoteServiceBindingStatement)");
        }

        public override void ExplicitVisit(CreateResourcePoolStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateResourcePoolStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateResourcePoolStatement)");
        }

        public override void ExplicitVisit(CreateRoleStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateRoleStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateRoleStatement)");
        }

        public override void ExplicitVisit(CreateRouteStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateRouteStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateRouteStatement)");
        }

        public override void ExplicitVisit(CreateRuleStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateRuleStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateRuleStatement)");
        }

        public override void ExplicitVisit(CreateSchemaStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateSchemaStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateSchemaStatement)");
        }

        public override void ExplicitVisit(CreateSearchPropertyListStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateSearchPropertyListStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateSearchPropertyListStatement)");
        }
        /*
        public override void ExplicitVisit(CreateSelectiveXmlIndexStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateSelectiveXmlIndexStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateSelectiveXmlIndexStatement)");
        }
        */
        public override void ExplicitVisit(CreateSequenceStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateSequenceStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateSequenceStatement)");
        }

        public override void ExplicitVisit(CreateServerAuditSpecificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateServerAuditSpecificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateServerAuditSpecificationStatement)");
        }

        public override void ExplicitVisit(CreateServerAuditStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateServerAuditStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateServerAuditStatement)");
        }

        public override void ExplicitVisit(CreateServerRoleStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateServerRoleStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateServerRoleStatement)");
        }

        public override void ExplicitVisit(CreateServiceStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateServiceStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateServiceStatement)");
        }

        public override void ExplicitVisit(CreateSpatialIndexStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateSpatialIndexStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateSpatialIndexStatement)");
        }

        public override void ExplicitVisit(CreateStatisticsStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateStatisticsStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateStatisticsStatement)");
        }

        public override void ExplicitVisit(CreateSymmetricKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateSymmetricKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateSymmetricKeyStatement)");
        }

        public override void ExplicitVisit(CreateSynonymStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateSynonymStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateSynonymStatement)");
        }

        public override void ExplicitVisit(CreateTableStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateTableStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateTableStatement)");
        }

        public override void ExplicitVisit(CreateTriggerStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateTriggerStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateTriggerStatement)");
        }

        public override void ExplicitVisit(CreateTypeStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateTypeStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateTypeStatement)");
        }

        public override void ExplicitVisit(CreateTypeTableStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateTypeTableStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateTypeTableStatement)");
        }

        public override void ExplicitVisit(CreateTypeUddtStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateTypeUddtStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateTypeUddtStatement)");
        }

        public override void ExplicitVisit(CreateTypeUdtStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateTypeUdtStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateTypeUdtStatement)");
        }

        public override void ExplicitVisit(CreateUserStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateUserStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateUserStatement)");
        }

        public override void ExplicitVisit(CreateViewStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateViewStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateViewStatement)");
        }

        public override void ExplicitVisit(CreateWorkloadGroupStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateWorkloadGroupStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateWorkloadGroupStatement)");
        }

        public override void ExplicitVisit(CreateXmlIndexStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateXmlIndexStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateXmlIndexStatement)");
        }

        public override void ExplicitVisit(CreateXmlSchemaCollectionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CreateXmlSchemaCollectionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreateXmlSchemaCollectionStatement)");
        }

        public override void ExplicitVisit(CreationDispositionKeyOption node)
        {
            Console.WriteLine("Start ExplicitVisit(CreationDispositionKeyOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CreationDispositionKeyOption)");
        }

        public override void ExplicitVisit(CredentialStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CredentialStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CredentialStatement)");
        }

        public override void ExplicitVisit(CryptoMechanism node)
        {
            Console.WriteLine("Start ExplicitVisit(CryptoMechanism)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CryptoMechanism)");
        }

        public override void ExplicitVisit(CubeGroupingSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(CubeGroupingSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CubeGroupingSpecification)");
        }

        public override void ExplicitVisit(CursorDefaultDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(CursorDefaultDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CursorDefaultDatabaseOption)");
        }

        public override void ExplicitVisit(CursorDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(CursorDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CursorDefinition)");
        }

        public override void ExplicitVisit(CursorId node)
        {
            Console.WriteLine("Start ExplicitVisit(CursorId)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CursorId)");
        }

        public override void ExplicitVisit(CursorOption node)
        {
            Console.WriteLine("Start ExplicitVisit(CursorOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CursorOption)");
        }

        public override void ExplicitVisit(CursorStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(CursorStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(CursorStatement)");
        }

        public override void ExplicitVisit(DatabaseAuditAction node)
        {
            Console.WriteLine("Start ExplicitVisit(DatabaseAuditAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DatabaseAuditAction)");
        }

        public override void ExplicitVisit(DatabaseEncryptionKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DatabaseEncryptionKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DatabaseEncryptionKeyStatement)");
        }

        public override void ExplicitVisit(DatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(DatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DatabaseOption)");
        }

        public override void ExplicitVisit(DataCompressionOption node)
        {
            Console.WriteLine("Start ExplicitVisit(DataCompressionOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DataCompressionOption)");
        }

        public override void ExplicitVisit(DataModificationSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(DataModificationSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DataModificationSpecification)");
        }

        public override void ExplicitVisit(DataModificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DataModificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DataModificationStatement)");
        }

        public override void ExplicitVisit(DataModificationTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(DataModificationTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DataModificationTableReference)");
        }

        public override void ExplicitVisit(DataTypeReference node)
        {
            Console.WriteLine("Start ExplicitVisit(DataTypeReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DataTypeReference)");
        }

        public override void ExplicitVisit(DataTypeSequenceOption node)
        {
            Console.WriteLine("Start ExplicitVisit(DataTypeSequenceOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DataTypeSequenceOption)");
        }

        public override void ExplicitVisit(DbccNamedLiteral node)
        {
            Console.WriteLine("Start ExplicitVisit(DbccNamedLiteral)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DbccNamedLiteral)");
        }

        public override void ExplicitVisit(DbccOption node)
        {
            Console.WriteLine("Start ExplicitVisit(DbccOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DbccOption)");
        }

        public override void ExplicitVisit(DbccStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DbccStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DbccStatement)");
        }

        public override void ExplicitVisit(DeallocateCursorStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DeallocateCursorStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DeallocateCursorStatement)");
        }

        public override void ExplicitVisit(DeclareCursorStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DeclareCursorStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DeclareCursorStatement)");
        }

        public override void ExplicitVisit(DeclareTableVariableBody node)
        {
            Console.WriteLine("Start ExplicitVisit(DeclareTableVariableBody)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DeclareTableVariableBody)");
        }

        public override void ExplicitVisit(DeclareTableVariableStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DeclareTableVariableStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DeclareTableVariableStatement)");
        }

        public override void ExplicitVisit(DeclareVariableElement node)
        {
            Console.WriteLine("Start ExplicitVisit(DeclareVariableElement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DeclareVariableElement)");
        }

        public override void ExplicitVisit(DeclareVariableStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DeclareVariableStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DeclareVariableStatement)");
        }

        public override void ExplicitVisit(DefaultConstraintDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(DefaultConstraintDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DefaultConstraintDefinition)");
        }

        public override void ExplicitVisit(DefaultLiteral node)
        {
            Console.WriteLine("Start ExplicitVisit(DefaultLiteral)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DefaultLiteral)");
        }

        public override void ExplicitVisit(DeleteMergeAction node)
        {
            Console.WriteLine("Start ExplicitVisit(DeleteMergeAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DeleteMergeAction)");
        }

        public override void ExplicitVisit(DeleteSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(DeleteSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DeleteSpecification)");
        }

        public override void ExplicitVisit(DeleteStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DeleteStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DeleteStatement)");
        }

        public override void ExplicitVisit(DenyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DenyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DenyStatement)");
        }

        public override void ExplicitVisit(DenyStatement80 node)
        {
            Console.WriteLine("Start ExplicitVisit(DenyStatement80)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DenyStatement80)");
        }

        public override void ExplicitVisit(DeviceInfo node)
        {
            Console.WriteLine("Start ExplicitVisit(DeviceInfo)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DeviceInfo)");
        }

        public override void ExplicitVisit(DialogOption node)
        {
            Console.WriteLine("Start ExplicitVisit(DialogOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DialogOption)");
        }

        public override void ExplicitVisit(DiskStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DiskStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DiskStatement)");
        }

        public override void ExplicitVisit(DiskStatementOption node)
        {
            Console.WriteLine("Start ExplicitVisit(DiskStatementOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DiskStatementOption)");
        }

        public override void ExplicitVisit(DropAggregateStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropAggregateStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropAggregateStatement)");
        }

        public override void ExplicitVisit(DropAlterFullTextIndexAction node)
        {
            Console.WriteLine("Start ExplicitVisit(DropAlterFullTextIndexAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropAlterFullTextIndexAction)");
        }

        public override void ExplicitVisit(DropApplicationRoleStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropApplicationRoleStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropApplicationRoleStatement)");
        }

        public override void ExplicitVisit(DropAssemblyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropAssemblyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropAssemblyStatement)");
        }

        public override void ExplicitVisit(DropAsymmetricKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropAsymmetricKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropAsymmetricKeyStatement)");
        }

        public override void ExplicitVisit(DropAvailabilityGroupStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropAvailabilityGroupStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropAvailabilityGroupStatement)");
        }

        public override void ExplicitVisit(DropBrokerPriorityStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropBrokerPriorityStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropBrokerPriorityStatement)");
        }

        public override void ExplicitVisit(DropCertificateStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropCertificateStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropCertificateStatement)");
        }

        public override void ExplicitVisit(DropChildObjectsStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropChildObjectsStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropChildObjectsStatement)");
        }

        public override void ExplicitVisit(DropClusteredConstraintMoveOption node)
        {
            Console.WriteLine("Start ExplicitVisit(DropClusteredConstraintMoveOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropClusteredConstraintMoveOption)");
        }

        public override void ExplicitVisit(DropClusteredConstraintOption node)
        {
            Console.WriteLine("Start ExplicitVisit(DropClusteredConstraintOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropClusteredConstraintOption)");
        }

        public override void ExplicitVisit(DropClusteredConstraintStateOption node)
        {
            Console.WriteLine("Start ExplicitVisit(DropClusteredConstraintStateOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropClusteredConstraintStateOption)");
        }

        public override void ExplicitVisit(DropClusteredConstraintValueOption node)
        {
            Console.WriteLine("Start ExplicitVisit(DropClusteredConstraintValueOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropClusteredConstraintValueOption)");
        }

        public override void ExplicitVisit(DropContractStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropContractStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropContractStatement)");
        }

        public override void ExplicitVisit(DropCredentialStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropCredentialStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropCredentialStatement)");
        }

        public override void ExplicitVisit(DropCryptographicProviderStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropCryptographicProviderStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropCryptographicProviderStatement)");
        }

        public override void ExplicitVisit(DropDatabaseAuditSpecificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropDatabaseAuditSpecificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropDatabaseAuditSpecificationStatement)");
        }

        public override void ExplicitVisit(DropDatabaseEncryptionKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropDatabaseEncryptionKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropDatabaseEncryptionKeyStatement)");
        }

        public override void ExplicitVisit(DropDatabaseStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropDatabaseStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropDatabaseStatement)");
        }

        public override void ExplicitVisit(DropDefaultStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropDefaultStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropDefaultStatement)");
        }

        public override void ExplicitVisit(DropEndpointStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropEndpointStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropEndpointStatement)");
        }

        public override void ExplicitVisit(DropEventNotificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropEventNotificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropEventNotificationStatement)");
        }

        public override void ExplicitVisit(DropEventSessionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropEventSessionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropEventSessionStatement)");
        }

        public override void ExplicitVisit(DropFederationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropFederationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropFederationStatement)");
        }

        public override void ExplicitVisit(DropFullTextCatalogStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropFullTextCatalogStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropFullTextCatalogStatement)");
        }

        public override void ExplicitVisit(DropFullTextIndexStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropFullTextIndexStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropFullTextIndexStatement)");
        }

        public override void ExplicitVisit(DropFullTextStopListStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropFullTextStopListStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropFullTextStopListStatement)");
        }

        public override void ExplicitVisit(DropFunctionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropFunctionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropFunctionStatement)");
        }

        public override void ExplicitVisit(DropIndexClause node)
        {
            Console.WriteLine("Start ExplicitVisit(DropIndexClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropIndexClause)");
        }

        public override void ExplicitVisit(DropIndexClauseBase node)
        {
            Console.WriteLine("Start ExplicitVisit(DropIndexClauseBase)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropIndexClauseBase)");
        }

        public override void ExplicitVisit(DropIndexStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropIndexStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropIndexStatement)");
        }

        public override void ExplicitVisit(DropLoginStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropLoginStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropLoginStatement)");
        }

        public override void ExplicitVisit(DropMasterKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropMasterKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropMasterKeyStatement)");
        }

        public override void ExplicitVisit(DropMemberAlterRoleAction node)
        {
            Console.WriteLine("Start ExplicitVisit(DropMemberAlterRoleAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropMemberAlterRoleAction)");
        }

        public override void ExplicitVisit(DropMessageTypeStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropMessageTypeStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropMessageTypeStatement)");
        }

        public override void ExplicitVisit(DropObjectsStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropObjectsStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropObjectsStatement)");
        }

        public override void ExplicitVisit(DropPartitionFunctionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropPartitionFunctionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropPartitionFunctionStatement)");
        }

        public override void ExplicitVisit(DropPartitionSchemeStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropPartitionSchemeStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropPartitionSchemeStatement)");
        }

        public override void ExplicitVisit(DropProcedureStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropProcedureStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropProcedureStatement)");
        }

        public override void ExplicitVisit(DropQueueStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropQueueStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropQueueStatement)");
        }

        public override void ExplicitVisit(DropRemoteServiceBindingStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropRemoteServiceBindingStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropRemoteServiceBindingStatement)");
        }

        public override void ExplicitVisit(DropResourcePoolStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropResourcePoolStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropResourcePoolStatement)");
        }

        public override void ExplicitVisit(DropRoleStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropRoleStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropRoleStatement)");
        }

        public override void ExplicitVisit(DropRouteStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropRouteStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropRouteStatement)");
        }

        public override void ExplicitVisit(DropRuleStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropRuleStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropRuleStatement)");
        }

        public override void ExplicitVisit(DropSchemaStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropSchemaStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropSchemaStatement)");
        }

        public override void ExplicitVisit(DropSearchPropertyListAction node)
        {
            Console.WriteLine("Start ExplicitVisit(DropSearchPropertyListAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropSearchPropertyListAction)");
        }

        public override void ExplicitVisit(DropSearchPropertyListStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropSearchPropertyListStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropSearchPropertyListStatement)");
        }

        public override void ExplicitVisit(DropSequenceStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropSequenceStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropSequenceStatement)");
        }

        public override void ExplicitVisit(DropServerAuditSpecificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropServerAuditSpecificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropServerAuditSpecificationStatement)");
        }

        public override void ExplicitVisit(DropServerAuditStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropServerAuditStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropServerAuditStatement)");
        }

        public override void ExplicitVisit(DropServerRoleStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropServerRoleStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropServerRoleStatement)");
        }

        public override void ExplicitVisit(DropServiceStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropServiceStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropServiceStatement)");
        }

        public override void ExplicitVisit(DropSignatureStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropSignatureStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropSignatureStatement)");
        }

        public override void ExplicitVisit(DropStatisticsStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropStatisticsStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropStatisticsStatement)");
        }

        public override void ExplicitVisit(DropSymmetricKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropSymmetricKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropSymmetricKeyStatement)");
        }

        public override void ExplicitVisit(DropSynonymStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropSynonymStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropSynonymStatement)");
        }

        public override void ExplicitVisit(DropTableStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropTableStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropTableStatement)");
        }

        public override void ExplicitVisit(DropTriggerStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropTriggerStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropTriggerStatement)");
        }

        public override void ExplicitVisit(DropTypeStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropTypeStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropTypeStatement)");
        }

        public override void ExplicitVisit(DropUnownedObjectStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropUnownedObjectStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropUnownedObjectStatement)");
        }

        public override void ExplicitVisit(DropUserStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropUserStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropUserStatement)");
        }

        public override void ExplicitVisit(DropViewStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropViewStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropViewStatement)");
        }

        public override void ExplicitVisit(DropWorkloadGroupStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropWorkloadGroupStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropWorkloadGroupStatement)");
        }

        public override void ExplicitVisit(DropXmlSchemaCollectionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(DropXmlSchemaCollectionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(DropXmlSchemaCollectionStatement)");
        }

        public override void ExplicitVisit(EnabledDisabledPayloadOption node)
        {
            Console.WriteLine("Start ExplicitVisit(EnabledDisabledPayloadOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EnabledDisabledPayloadOption)");
        }

        public override void ExplicitVisit(EnableDisableTriggerStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(EnableDisableTriggerStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EnableDisableTriggerStatement)");
        }

        public override void ExplicitVisit(EncryptionPayloadOption node)
        {
            Console.WriteLine("Start ExplicitVisit(EncryptionPayloadOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EncryptionPayloadOption)");
        }

        public override void ExplicitVisit(EncryptionSource node)
        {
            Console.WriteLine("Start ExplicitVisit(EncryptionSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EncryptionSource)");
        }

        public override void ExplicitVisit(EndConversationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(EndConversationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EndConversationStatement)");
        }

        public override void ExplicitVisit(EndpointAffinity node)
        {
            Console.WriteLine("Start ExplicitVisit(EndpointAffinity)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EndpointAffinity)");
        }

        public override void ExplicitVisit(EndpointProtocolOption node)
        {
            Console.WriteLine("Start ExplicitVisit(EndpointProtocolOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EndpointProtocolOption)");
        }

        public override void ExplicitVisit(EventDeclaration node)
        {
            Console.WriteLine("Start ExplicitVisit(EventDeclaration)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EventDeclaration)");
        }

        public override void ExplicitVisit(EventDeclarationCompareFunctionParameter node)
        {
            Console.WriteLine("Start ExplicitVisit(EventDeclarationCompareFunctionParameter)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EventDeclarationCompareFunctionParameter)");
        }

        public override void ExplicitVisit(EventDeclarationSetParameter node)
        {
            Console.WriteLine("Start ExplicitVisit(EventDeclarationSetParameter)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EventDeclarationSetParameter)");
        }

        public override void ExplicitVisit(EventGroupContainer node)
        {
            Console.WriteLine("Start ExplicitVisit(EventGroupContainer)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EventGroupContainer)");
        }

        public override void ExplicitVisit(EventNotificationObjectScope node)
        {
            Console.WriteLine("Start ExplicitVisit(EventNotificationObjectScope)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EventNotificationObjectScope)");
        }

        public override void ExplicitVisit(EventRetentionSessionOption node)
        {
            Console.WriteLine("Start ExplicitVisit(EventRetentionSessionOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EventRetentionSessionOption)");
        }

        public override void ExplicitVisit(EventSessionObjectName node)
        {
            Console.WriteLine("Start ExplicitVisit(EventSessionObjectName)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EventSessionObjectName)");
        }

        public override void ExplicitVisit(EventSessionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(EventSessionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EventSessionStatement)");
        }

        public override void ExplicitVisit(EventTypeContainer node)
        {
            Console.WriteLine("Start ExplicitVisit(EventTypeContainer)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EventTypeContainer)");
        }

        public override void ExplicitVisit(EventTypeGroupContainer node)
        {
            Console.WriteLine("Start ExplicitVisit(EventTypeGroupContainer)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(EventTypeGroupContainer)");
        }

        public override void ExplicitVisit(ExecutableEntity node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecutableEntity)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecutableEntity)");
        }

        public override void ExplicitVisit(ExecutableProcedureReference node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecutableProcedureReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecutableProcedureReference)");
        }

        public override void ExplicitVisit(ExecutableStringList node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecutableStringList)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecutableStringList)");
        }

        public override void ExplicitVisit(ExecuteAsClause node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecuteAsClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecuteAsClause)");
        }

        public override void ExplicitVisit(ExecuteAsFunctionOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecuteAsFunctionOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecuteAsFunctionOption)");
        }

        public override void ExplicitVisit(ExecuteAsProcedureOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecuteAsProcedureOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecuteAsProcedureOption)");
        }

        public override void ExplicitVisit(ExecuteAsStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecuteAsStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecuteAsStatement)");
        }

        public override void ExplicitVisit(ExecuteAsTriggerOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecuteAsTriggerOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecuteAsTriggerOption)");
        }

        public override void ExplicitVisit(ExecuteContext node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecuteContext)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecuteContext)");
        }

        public override void ExplicitVisit(ExecuteInsertSource node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecuteInsertSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecuteInsertSource)");
        }

        public override void ExplicitVisit(ExecuteOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecuteOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecuteOption)");
        }

        public override void ExplicitVisit(ExecuteParameter node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecuteParameter)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecuteParameter)");
        }

        public override void ExplicitVisit(ExecuteSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecuteSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecuteSpecification)");
        }

        public override void ExplicitVisit(ExecuteStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(ExecuteStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExecuteStatement)");
        }

        public override void ExplicitVisit(ExistsPredicate node)
        {
            Console.WriteLine("Start ExplicitVisit(ExistsPredicate)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExistsPredicate)");
        }

        public override void ExplicitVisit(ExpressionCallTarget node)
        {
            Console.WriteLine("Start ExplicitVisit(ExpressionCallTarget)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExpressionCallTarget)");
        }

        public override void ExplicitVisit(ExpressionGroupingSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(ExpressionGroupingSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExpressionGroupingSpecification)");
        }

        public override void ExplicitVisit(ExpressionWithSortOrder node)
        {
            Console.WriteLine("Start ExplicitVisit(ExpressionWithSortOrder)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExpressionWithSortOrder)");
        }

        public override void ExplicitVisit(ExtractFromExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(ExtractFromExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ExtractFromExpression)");
        }

        public override void ExplicitVisit(FailoverModeReplicaOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FailoverModeReplicaOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FailoverModeReplicaOption)");
        }

        public override void ExplicitVisit(FederationScheme node)
        {
            Console.WriteLine("Start ExplicitVisit(FederationScheme)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FederationScheme)");
        }

        public override void ExplicitVisit(FetchCursorStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(FetchCursorStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FetchCursorStatement)");
        }

        public override void ExplicitVisit(FetchType node)
        {
            Console.WriteLine("Start ExplicitVisit(FetchType)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FetchType)");
        }

        public override void ExplicitVisit(FileDeclaration node)
        {
            Console.WriteLine("Start ExplicitVisit(FileDeclaration)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileDeclaration)");
        }

        public override void ExplicitVisit(FileDeclarationOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FileDeclarationOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileDeclarationOption)");
        }

        public override void ExplicitVisit(FileEncryptionSource node)
        {
            Console.WriteLine("Start ExplicitVisit(FileEncryptionSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileEncryptionSource)");
        }

        public override void ExplicitVisit(FileGroupDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(FileGroupDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileGroupDefinition)");
        }

        public override void ExplicitVisit(FileGroupOrPartitionScheme node)
        {
            Console.WriteLine("Start ExplicitVisit(FileGroupOrPartitionScheme)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileGroupOrPartitionScheme)");
        }

        public override void ExplicitVisit(FileGrowthFileDeclarationOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FileGrowthFileDeclarationOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileGrowthFileDeclarationOption)");
        }

        public override void ExplicitVisit(FileNameFileDeclarationOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FileNameFileDeclarationOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileNameFileDeclarationOption)");
        }

        public override void ExplicitVisit(FileStreamDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FileStreamDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileStreamDatabaseOption)");
        }

        public override void ExplicitVisit(FileStreamOnDropIndexOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FileStreamOnDropIndexOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileStreamOnDropIndexOption)");
        }

        public override void ExplicitVisit(FileStreamOnTableOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FileStreamOnTableOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileStreamOnTableOption)");
        }

        public override void ExplicitVisit(FileStreamRestoreOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FileStreamRestoreOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileStreamRestoreOption)");
        }

        public override void ExplicitVisit(FileTableCollateFileNameTableOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FileTableCollateFileNameTableOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileTableCollateFileNameTableOption)");
        }

        public override void ExplicitVisit(FileTableConstraintNameTableOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FileTableConstraintNameTableOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileTableConstraintNameTableOption)");
        }

        public override void ExplicitVisit(FileTableDirectoryTableOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FileTableDirectoryTableOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FileTableDirectoryTableOption)");
        }

        public override void ExplicitVisit(ForceSeekTableHint node)
        {
            Console.WriteLine("Start ExplicitVisit(ForceSeekTableHint)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ForceSeekTableHint)");
        }

        public override void ExplicitVisit(ForClause node)
        {
            Console.WriteLine("Start ExplicitVisit(ForClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ForClause)");
        }

        public override void ExplicitVisit(ForeignKeyConstraintDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(ForeignKeyConstraintDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ForeignKeyConstraintDefinition)");
        }

        public override void ExplicitVisit(FromClause node)
        {
            Console.WriteLine("Start ExplicitVisit(FromClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FromClause)");
        }

        public override void ExplicitVisit(FullTextCatalogAndFileGroup node)
        {
            Console.WriteLine("Start ExplicitVisit(FullTextCatalogAndFileGroup)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FullTextCatalogAndFileGroup)");
        }

        public override void ExplicitVisit(FullTextCatalogOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FullTextCatalogOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FullTextCatalogOption)");
        }

        public override void ExplicitVisit(FullTextCatalogStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(FullTextCatalogStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FullTextCatalogStatement)");
        }

        public override void ExplicitVisit(FullTextIndexColumn node)
        {
            Console.WriteLine("Start ExplicitVisit(FullTextIndexColumn)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FullTextIndexColumn)");
        }

        public override void ExplicitVisit(FullTextIndexOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FullTextIndexOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FullTextIndexOption)");
        }

        public override void ExplicitVisit(FullTextPredicate node)
        {
            Console.WriteLine("Start ExplicitVisit(FullTextPredicate)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FullTextPredicate)");
        }

        public override void ExplicitVisit(FullTextStopListAction node)
        {
            Console.WriteLine("Start ExplicitVisit(FullTextStopListAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FullTextStopListAction)");
        }

        public override void ExplicitVisit(FullTextTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(FullTextTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FullTextTableReference)");
        }

        public override void ExplicitVisit(FunctionCall node)
        {
            Console.WriteLine("Start ExplicitVisit(FunctionCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FunctionCall)");
        }

        public override void ExplicitVisit(FunctionCallSetClause node)
        {
            Console.WriteLine("Start ExplicitVisit(FunctionCallSetClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FunctionCallSetClause)");
        }

        public override void ExplicitVisit(FunctionOption node)
        {
            Console.WriteLine("Start ExplicitVisit(FunctionOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FunctionOption)");
        }

        public override void ExplicitVisit(FunctionReturnType node)
        {
            Console.WriteLine("Start ExplicitVisit(FunctionReturnType)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FunctionReturnType)");
        }

        public override void ExplicitVisit(FunctionStatementBody node)
        {
            Console.WriteLine("Start ExplicitVisit(FunctionStatementBody)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(FunctionStatementBody)");
        }

        public override void ExplicitVisit(GeneralSetCommand node)
        {
            Console.WriteLine("Start ExplicitVisit(GeneralSetCommand)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(GeneralSetCommand)");
        }

        public override void ExplicitVisit(GetConversationGroupStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(GetConversationGroupStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(GetConversationGroupStatement)");
        }

        public override void ExplicitVisit(GlobalVariableExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(GlobalVariableExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(GlobalVariableExpression)");
        }

        public override void ExplicitVisit(GoToStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(GoToStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(GoToStatement)");
        }

        public override void ExplicitVisit(GrandTotalGroupingSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(GrandTotalGroupingSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(GrandTotalGroupingSpecification)");
        }

        public override void ExplicitVisit(GrantStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(GrantStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(GrantStatement)");
        }

        public override void ExplicitVisit(GrantStatement80 node)
        {
            Console.WriteLine("Start ExplicitVisit(GrantStatement80)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(GrantStatement80)");
        }

        public override void ExplicitVisit(GridParameter node)
        {
            Console.WriteLine("Start ExplicitVisit(GridParameter)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(GridParameter)");
        }

        public override void ExplicitVisit(GridsSpatialIndexOption node)
        {
            Console.WriteLine("Start ExplicitVisit(GridsSpatialIndexOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(GridsSpatialIndexOption)");
        }

        public override void ExplicitVisit(GroupByClause node)
        {
            Console.WriteLine("Start ExplicitVisit(GroupByClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(GroupByClause)");
        }

        public override void ExplicitVisit(GroupingSetsGroupingSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(GroupingSetsGroupingSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(GroupingSetsGroupingSpecification)");
        }

        public override void ExplicitVisit(GroupingSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(GroupingSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(GroupingSpecification)");
        }

        public override void ExplicitVisit(HadrAvailabilityGroupDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(HadrAvailabilityGroupDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(HadrAvailabilityGroupDatabaseOption)");
        }

        public override void ExplicitVisit(HadrDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(HadrDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(HadrDatabaseOption)");
        }

        public override void ExplicitVisit(HavingClause node)
        {
            Console.WriteLine("Start ExplicitVisit(HavingClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(HavingClause)");
        }

        public override void ExplicitVisit(Identifier node)
        {
            Console.WriteLine("Start ExplicitVisit(Identifier)");
            Console.WriteLine("Identifier : " + node.Value);
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(Identifier)");
        }

        public override void ExplicitVisit(IdentifierDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(IdentifierDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IdentifierDatabaseOption)");
        }

        public override void ExplicitVisit(IdentifierLiteral node)
        {
            Console.WriteLine("Start ExplicitVisit(IdentifierLiteral)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IdentifierLiteral)");
        }

        public override void ExplicitVisit(IdentifierOrValueExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(IdentifierOrValueExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IdentifierOrValueExpression)");
        }

        public override void ExplicitVisit(IdentifierPrincipalOption node)
        {
            Console.WriteLine("Start ExplicitVisit(IdentifierPrincipalOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IdentifierPrincipalOption)");
        }

        public override void ExplicitVisit(IdentifierSnippet node)
        {
            Console.WriteLine("Start ExplicitVisit(IdentifierSnippet)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IdentifierSnippet)");
        }

        public override void ExplicitVisit(IdentityFunctionCall node)
        {
            Console.WriteLine("Start ExplicitVisit(IdentityFunctionCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IdentityFunctionCall)");
        }

        public override void ExplicitVisit(IdentityOptions node)
        {
            Console.WriteLine("Start ExplicitVisit(IdentityOptions)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IdentityOptions)");
        }

        public override void ExplicitVisit(IdentityValueKeyOption node)
        {
            Console.WriteLine("Start ExplicitVisit(IdentityValueKeyOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IdentityValueKeyOption)");
        }

        public override void ExplicitVisit(IfStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(IfStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IfStatement)");
        }

        public override void ExplicitVisit(IIfCall node)
        {
            Console.WriteLine("Start ExplicitVisit(IIfCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IIfCall)");
        }

        public override void ExplicitVisit(IndexExpressionOption node)
        {
            Console.WriteLine("Start ExplicitVisit(IndexExpressionOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IndexExpressionOption)");
        }

        public override void ExplicitVisit(IndexOption node)
        {
            Console.WriteLine("Start ExplicitVisit(IndexOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IndexOption)");
        }

        public override void ExplicitVisit(IndexStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(IndexStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IndexStatement)");
        }

        public override void ExplicitVisit(IndexStateOption node)
        {
            Console.WriteLine("Start ExplicitVisit(IndexStateOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IndexStateOption)");
        }

        public override void ExplicitVisit(IndexTableHint node)
        {
            Console.WriteLine("Start ExplicitVisit(IndexTableHint)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IndexTableHint)");
        }

        public override void ExplicitVisit(InlineDerivedTable node)
        {
            Console.WriteLine("Start ExplicitVisit(InlineDerivedTable)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(InlineDerivedTable)");
        }

        public override void ExplicitVisit(InlineResultSetDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(InlineResultSetDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(InlineResultSetDefinition)");
        }

        public override void ExplicitVisit(InPredicate node)
        {
            Console.WriteLine("Start ExplicitVisit(InPredicate)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(InPredicate)");
        }

        public override void ExplicitVisit(InsertBulkColumnDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(InsertBulkColumnDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(InsertBulkColumnDefinition)");
        }

        public override void ExplicitVisit(InsertBulkStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(InsertBulkStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(InsertBulkStatement)");
        }

        public override void ExplicitVisit(InsertMergeAction node)
        {
            Console.WriteLine("Start ExplicitVisit(InsertMergeAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(InsertMergeAction)");
        }

        public override void ExplicitVisit(InsertSource node)
        {
            Console.WriteLine("Start ExplicitVisit(InsertSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(InsertSource)");
        }

        public override void ExplicitVisit(InsertSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(InsertSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(InsertSpecification)");
        }

        public override void ExplicitVisit(InsertStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(InsertStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(InsertStatement)");
        }

        public override void ExplicitVisit(IntegerLiteral node)
        {
            Console.WriteLine("Start ExplicitVisit(IntegerLiteral)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IntegerLiteral)");
        }

        public override void ExplicitVisit(InternalOpenRowset node)
        {
            Console.WriteLine("Start ExplicitVisit(InternalOpenRowset)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(InternalOpenRowset)");
        }

        public override void ExplicitVisit(IPv4 node)
        {
            Console.WriteLine("Start ExplicitVisit(IPv4)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(IPv4)");
        }

        public override void ExplicitVisit(JoinParenthesisTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(JoinParenthesisTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(JoinParenthesisTableReference)");
        }

        public override void ExplicitVisit(JoinTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(JoinTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(JoinTableReference)");
        }

        public override void ExplicitVisit(KeyOption node)
        {
            Console.WriteLine("Start ExplicitVisit(KeyOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(KeyOption)");
        }

        public override void ExplicitVisit(KeySourceKeyOption node)
        {
            Console.WriteLine("Start ExplicitVisit(KeySourceKeyOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(KeySourceKeyOption)");
        }

        public override void ExplicitVisit(KillQueryNotificationSubscriptionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(KillQueryNotificationSubscriptionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(KillQueryNotificationSubscriptionStatement)");
        }

        public override void ExplicitVisit(KillStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(KillStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(KillStatement)");
        }

        public override void ExplicitVisit(KillStatsJobStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(KillStatsJobStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(KillStatsJobStatement)");
        }

        public override void ExplicitVisit(LabelStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(LabelStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LabelStatement)");
        }

        public override void ExplicitVisit(LeftFunctionCall node)
        {
            Console.WriteLine("Start ExplicitVisit(LeftFunctionCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LeftFunctionCall)");
        }

        public override void ExplicitVisit(LikePredicate node)
        {
            Console.WriteLine("Start ExplicitVisit(LikePredicate)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LikePredicate)");
        }

        public override void ExplicitVisit(LineNoStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(LineNoStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LineNoStatement)");
        }

        public override void ExplicitVisit(ListenerIPEndpointProtocolOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ListenerIPEndpointProtocolOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ListenerIPEndpointProtocolOption)");
        }

        public override void ExplicitVisit(Literal node)
        {
            Console.WriteLine("Start ExplicitVisit(Literal)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(Literal)");
        }

        public override void ExplicitVisit(LiteralAuditTargetOption node)
        {
            Console.WriteLine("Start ExplicitVisit(LiteralAuditTargetOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LiteralAuditTargetOption)");
        }

        public override void ExplicitVisit(LiteralAvailabilityGroupOption node)
        {
            Console.WriteLine("Start ExplicitVisit(LiteralAvailabilityGroupOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LiteralAvailabilityGroupOption)");
        }

        public override void ExplicitVisit(LiteralBulkInsertOption node)
        {
            Console.WriteLine("Start ExplicitVisit(LiteralBulkInsertOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LiteralBulkInsertOption)");
        }

        public override void ExplicitVisit(LiteralDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(LiteralDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LiteralDatabaseOption)");
        }

        public override void ExplicitVisit(LiteralEndpointProtocolOption node)
        {
            Console.WriteLine("Start ExplicitVisit(LiteralEndpointProtocolOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LiteralEndpointProtocolOption)");
        }

        public override void ExplicitVisit(LiteralOptimizerHint node)
        {
            Console.WriteLine("Start ExplicitVisit(LiteralOptimizerHint)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LiteralOptimizerHint)");
        }

        public override void ExplicitVisit(LiteralPayloadOption node)
        {
            Console.WriteLine("Start ExplicitVisit(LiteralPayloadOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LiteralPayloadOption)");
        }

        public override void ExplicitVisit(LiteralPrincipalOption node)
        {
            Console.WriteLine("Start ExplicitVisit(LiteralPrincipalOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LiteralPrincipalOption)");
        }

        public override void ExplicitVisit(LiteralRange node)
        {
            Console.WriteLine("Start ExplicitVisit(LiteralRange)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LiteralRange)");
        }

        public override void ExplicitVisit(LiteralReplicaOption node)
        {
            Console.WriteLine("Start ExplicitVisit(LiteralReplicaOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LiteralReplicaOption)");
        }

        public override void ExplicitVisit(LiteralSessionOption node)
        {
            Console.WriteLine("Start ExplicitVisit(LiteralSessionOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LiteralSessionOption)");
        }

        public override void ExplicitVisit(LiteralStatisticsOption node)
        {
            Console.WriteLine("Start ExplicitVisit(LiteralStatisticsOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LiteralStatisticsOption)");
        }

        public override void ExplicitVisit(LiteralTableHint node)
        {
            Console.WriteLine("Start ExplicitVisit(LiteralTableHint)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LiteralTableHint)");
        }

        public override void ExplicitVisit(LockEscalationTableOption node)
        {
            Console.WriteLine("Start ExplicitVisit(LockEscalationTableOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LockEscalationTableOption)");
        }

        public override void ExplicitVisit(LoginTypePayloadOption node)
        {
            Console.WriteLine("Start ExplicitVisit(LoginTypePayloadOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(LoginTypePayloadOption)");
        }

        public override void ExplicitVisit(MasterKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(MasterKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MasterKeyStatement)");
        }

        public override void ExplicitVisit(MaxDispatchLatencySessionOption node)
        {
            Console.WriteLine("Start ExplicitVisit(MaxDispatchLatencySessionOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MaxDispatchLatencySessionOption)");
        }

        public override void ExplicitVisit(MaxLiteral node)
        {
            Console.WriteLine("Start ExplicitVisit(MaxLiteral)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MaxLiteral)");
        }

        public override void ExplicitVisit(MaxRolloverFilesAuditTargetOption node)
        {
            Console.WriteLine("Start ExplicitVisit(MaxRolloverFilesAuditTargetOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MaxRolloverFilesAuditTargetOption)");
        }

        public override void ExplicitVisit(MaxSizeAuditTargetOption node)
        {
            Console.WriteLine("Start ExplicitVisit(MaxSizeAuditTargetOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MaxSizeAuditTargetOption)");
        }

        public override void ExplicitVisit(MaxSizeDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(MaxSizeDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MaxSizeDatabaseOption)");
        }

        public override void ExplicitVisit(MaxSizeFileDeclarationOption node)
        {
            Console.WriteLine("Start ExplicitVisit(MaxSizeFileDeclarationOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MaxSizeFileDeclarationOption)");
        }

        public override void ExplicitVisit(MemoryPartitionSessionOption node)
        {
            Console.WriteLine("Start ExplicitVisit(MemoryPartitionSessionOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MemoryPartitionSessionOption)");
        }

        public override void ExplicitVisit(MergeAction node)
        {
            Console.WriteLine("Start ExplicitVisit(MergeAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MergeAction)");
        }

        public override void ExplicitVisit(MergeActionClause node)
        {
            Console.WriteLine("Start ExplicitVisit(MergeActionClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MergeActionClause)");
        }

        public override void ExplicitVisit(MergeSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(MergeSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MergeSpecification)");
        }

        public override void ExplicitVisit(MergeStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(MergeStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MergeStatement)");
        }

        public override void ExplicitVisit(MessageTypeStatementBase node)
        {
            Console.WriteLine("Start ExplicitVisit(MessageTypeStatementBase)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MessageTypeStatementBase)");
        }

        public override void ExplicitVisit(MethodSpecifier node)
        {
            Console.WriteLine("Start ExplicitVisit(MethodSpecifier)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MethodSpecifier)");
        }

        public override void ExplicitVisit(MirrorToClause node)
        {
            Console.WriteLine("Start ExplicitVisit(MirrorToClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MirrorToClause)");
        }

        public override void ExplicitVisit(MoneyLiteral node)
        {
            Console.WriteLine("Start ExplicitVisit(MoneyLiteral)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MoneyLiteral)");
        }

        public override void ExplicitVisit(MoveConversationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(MoveConversationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MoveConversationStatement)");
        }

        public override void ExplicitVisit(MoveRestoreOption node)
        {
            Console.WriteLine("Start ExplicitVisit(MoveRestoreOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MoveRestoreOption)");
        }

        public override void ExplicitVisit(MoveToDropIndexOption node)
        {
            Console.WriteLine("Start ExplicitVisit(MoveToDropIndexOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MoveToDropIndexOption)");
        }

        public override void ExplicitVisit(MultiPartIdentifier node)
        {
            Console.WriteLine("Start ExplicitVisit(MultiPartIdentifier)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MultiPartIdentifier)");
        }

        public override void ExplicitVisit(MultiPartIdentifierCallTarget node)
        {
            Console.WriteLine("Start ExplicitVisit(MultiPartIdentifierCallTarget)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(MultiPartIdentifierCallTarget)");
        }

        public override void ExplicitVisit(NamedTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(NamedTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(NamedTableReference)");
        }

        public override void ExplicitVisit(NameFileDeclarationOption node)
        {
            Console.WriteLine("Start ExplicitVisit(NameFileDeclarationOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(NameFileDeclarationOption)");
        }

        public override void ExplicitVisit(NextValueForExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(NextValueForExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(NextValueForExpression)");
        }

        public override void ExplicitVisit(NullableConstraintDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(NullableConstraintDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(NullableConstraintDefinition)");
        }

        public override void ExplicitVisit(NullIfExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(NullIfExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(NullIfExpression)");
        }

        public override void ExplicitVisit(NullLiteral node)
        {
            Console.WriteLine("Start ExplicitVisit(NullLiteral)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(NullLiteral)");
        }

        public override void ExplicitVisit(NumericLiteral node)
        {
            Console.WriteLine("Start ExplicitVisit(NumericLiteral)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(NumericLiteral)");
        }

        public override void ExplicitVisit(OdbcConvertSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(OdbcConvertSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OdbcConvertSpecification)");
        }

        public override void ExplicitVisit(OdbcFunctionCall node)
        {
            Console.WriteLine("Start ExplicitVisit(OdbcFunctionCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OdbcFunctionCall)");
        }

        public override void ExplicitVisit(OdbcLiteral node)
        {
            Console.WriteLine("Start ExplicitVisit(OdbcLiteral)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OdbcLiteral)");
        }

        public override void ExplicitVisit(OdbcQualifiedJoinTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(OdbcQualifiedJoinTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OdbcQualifiedJoinTableReference)");
        }

        public override void ExplicitVisit(OffsetClause node)
        {
            Console.WriteLine("Start ExplicitVisit(OffsetClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OffsetClause)");
        }

        public override void ExplicitVisit(OnFailureAuditOption node)
        {
            Console.WriteLine("Start ExplicitVisit(OnFailureAuditOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OnFailureAuditOption)");
        }

        public override void ExplicitVisit(OnOffAssemblyOption node)
        {
            Console.WriteLine("Start ExplicitVisit(OnOffAssemblyOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OnOffAssemblyOption)");
        }

        public override void ExplicitVisit(OnOffAuditTargetOption node)
        {
            Console.WriteLine("Start ExplicitVisit(OnOffAuditTargetOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OnOffAuditTargetOption)");
        }

        public override void ExplicitVisit(OnOffDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(OnOffDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OnOffDatabaseOption)");
        }

        public override void ExplicitVisit(OnOffDialogOption node)
        {
            Console.WriteLine("Start ExplicitVisit(OnOffDialogOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OnOffDialogOption)");
        }

        public override void ExplicitVisit(OnOffFullTextCatalogOption node)
        {
            Console.WriteLine("Start ExplicitVisit(OnOffFullTextCatalogOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OnOffFullTextCatalogOption)");
        }

        public override void ExplicitVisit(OnOffPrincipalOption node)
        {
            Console.WriteLine("Start ExplicitVisit(OnOffPrincipalOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OnOffPrincipalOption)");
        }

        public override void ExplicitVisit(OnOffRemoteServiceBindingOption node)
        {
            Console.WriteLine("Start ExplicitVisit(OnOffRemoteServiceBindingOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OnOffRemoteServiceBindingOption)");
        }

        public override void ExplicitVisit(OnOffSessionOption node)
        {
            Console.WriteLine("Start ExplicitVisit(OnOffSessionOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OnOffSessionOption)");
        }

        public override void ExplicitVisit(OpenCursorStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(OpenCursorStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OpenCursorStatement)");
        }

        public override void ExplicitVisit(OpenMasterKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(OpenMasterKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OpenMasterKeyStatement)");
        }

        public override void ExplicitVisit(OpenQueryTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(OpenQueryTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OpenQueryTableReference)");
        }

        public override void ExplicitVisit(OpenRowsetTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(OpenRowsetTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OpenRowsetTableReference)");
        }

        public override void ExplicitVisit(OpenSymmetricKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(OpenSymmetricKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OpenSymmetricKeyStatement)");
        }

        public override void ExplicitVisit(OpenXmlTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(OpenXmlTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OpenXmlTableReference)");
        }

        public override void ExplicitVisit(OptimizeForOptimizerHint node)
        {
            Console.WriteLine("Start ExplicitVisit(OptimizeForOptimizerHint)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OptimizeForOptimizerHint)");
        }

        public override void ExplicitVisit(OptimizerHint node)
        {
            Console.WriteLine("Start ExplicitVisit(OptimizerHint)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OptimizerHint)");
        }

        public override void ExplicitVisit(OrderBulkInsertOption node)
        {
            Console.WriteLine("Start ExplicitVisit(OrderBulkInsertOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OrderBulkInsertOption)");
        }

        public override void ExplicitVisit(OrderByClause node)
        {
            Console.WriteLine("Start ExplicitVisit(OrderByClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OrderByClause)");
        }

        public override void ExplicitVisit(OutputClause node)
        {
            Console.WriteLine("Start ExplicitVisit(OutputClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OutputClause)");
        }

        public override void ExplicitVisit(OutputIntoClause node)
        {
            Console.WriteLine("Start ExplicitVisit(OutputIntoClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OutputIntoClause)");
        }

        public override void ExplicitVisit(OverClause node)
        {
            Console.WriteLine("Start ExplicitVisit(OverClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(OverClause)");
        }

        public override void ExplicitVisit(PageVerifyDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(PageVerifyDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PageVerifyDatabaseOption)");
        }

        public override void ExplicitVisit(ParameterizationDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ParameterizationDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ParameterizationDatabaseOption)");
        }

        public override void ExplicitVisit(ParameterizedDataTypeReference node)
        {
            Console.WriteLine("Start ExplicitVisit(ParameterizedDataTypeReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ParameterizedDataTypeReference)");
        }

        public override void ExplicitVisit(ParameterlessCall node)
        {
            Console.WriteLine("Start ExplicitVisit(ParameterlessCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ParameterlessCall)");
        }

        public override void ExplicitVisit(ParenthesisExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(ParenthesisExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ParenthesisExpression)");
        }

        public override void ExplicitVisit(ParseCall node)
        {
            Console.WriteLine("Start ExplicitVisit(ParseCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ParseCall)");
        }

        public override void ExplicitVisit(PartitionFunctionCall node)
        {
            Console.WriteLine("Start ExplicitVisit(PartitionFunctionCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PartitionFunctionCall)");
        }

        public override void ExplicitVisit(PartitionParameterType node)
        {
            Console.WriteLine("Start ExplicitVisit(PartitionParameterType)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PartitionParameterType)");
        }

        public override void ExplicitVisit(PartitionSpecifier node)
        {
            Console.WriteLine("Start ExplicitVisit(PartitionSpecifier)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PartitionSpecifier)");
        }

        public override void ExplicitVisit(PartnerDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(PartnerDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PartnerDatabaseOption)");
        }

        public override void ExplicitVisit(PasswordAlterPrincipalOption node)
        {
            Console.WriteLine("Start ExplicitVisit(PasswordAlterPrincipalOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PasswordAlterPrincipalOption)");
        }

        public override void ExplicitVisit(PasswordCreateLoginSource node)
        {
            Console.WriteLine("Start ExplicitVisit(PasswordCreateLoginSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PasswordCreateLoginSource)");
        }

        public override void ExplicitVisit(PayloadOption node)
        {
            Console.WriteLine("Start ExplicitVisit(PayloadOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PayloadOption)");
        }

        public override void ExplicitVisit(Permission node)
        {
            Console.WriteLine("Start ExplicitVisit(Permission)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(Permission)");
        }

        public override void ExplicitVisit(PermissionSetAssemblyOption node)
        {
            Console.WriteLine("Start ExplicitVisit(PermissionSetAssemblyOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PermissionSetAssemblyOption)");
        }

        public override void ExplicitVisit(PivotedTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(PivotedTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PivotedTableReference)");
        }

        public override void ExplicitVisit(PortsEndpointProtocolOption node)
        {
            Console.WriteLine("Start ExplicitVisit(PortsEndpointProtocolOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PortsEndpointProtocolOption)");
        }

        public override void ExplicitVisit(PredicateSetStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(PredicateSetStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PredicateSetStatement)");
        }

        public override void ExplicitVisit(PrimaryExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(PrimaryExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PrimaryExpression)");
        }

        public override void ExplicitVisit(PrimaryRoleReplicaOption node)
        {
            Console.WriteLine("Start ExplicitVisit(PrimaryRoleReplicaOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PrimaryRoleReplicaOption)");
        }

        public override void ExplicitVisit(PrincipalOption node)
        {
            Console.WriteLine("Start ExplicitVisit(PrincipalOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PrincipalOption)");
        }

        public override void ExplicitVisit(PrintStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(PrintStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PrintStatement)");
        }

        public override void ExplicitVisit(Privilege80 node)
        {
            Console.WriteLine("Start ExplicitVisit(Privilege80)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(Privilege80)");
        }

        public override void ExplicitVisit(PrivilegeSecurityElement80 node)
        {
            Console.WriteLine("Start ExplicitVisit(PrivilegeSecurityElement80)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(PrivilegeSecurityElement80)");
        }

        public override void ExplicitVisit(ProcedureOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ProcedureOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ProcedureOption)");
        }

        public override void ExplicitVisit(ProcedureParameter node)
        {
            Console.WriteLine("Start ExplicitVisit(ProcedureParameter)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ProcedureParameter)");
        }

        public override void ExplicitVisit(ProcedureReference node)
        {
            Console.WriteLine("Start ExplicitVisit(ProcedureReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ProcedureReference)");
        }

        public override void ExplicitVisit(ProcedureReferenceName node)
        {
            Console.WriteLine("Start ExplicitVisit(ProcedureReferenceName)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ProcedureReferenceName)");
        }

        public override void ExplicitVisit(ProcedureStatementBody node)
        {
            Console.WriteLine("Start ExplicitVisit(ProcedureStatementBody)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ProcedureStatementBody)");
        }

        public override void ExplicitVisit(ProcedureStatementBodyBase node)
        {
            Console.WriteLine("Start ExplicitVisit(ProcedureStatementBodyBase)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ProcedureStatementBodyBase)");
        }

        public override void ExplicitVisit(ProcessAffinityRange node)
        {
            Console.WriteLine("Start ExplicitVisit(ProcessAffinityRange)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ProcessAffinityRange)");
        }

        public override void ExplicitVisit(ProviderEncryptionSource node)
        {
            Console.WriteLine("Start ExplicitVisit(ProviderEncryptionSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ProviderEncryptionSource)");
        }

        public override void ExplicitVisit(ProviderKeyNameKeyOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ProviderKeyNameKeyOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ProviderKeyNameKeyOption)");
        }

        public override void ExplicitVisit(QualifiedJoin node)
        {
            Console.WriteLine("Start ExplicitVisit(QualifiedJoin)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(QualifiedJoin)");
        }

        public override void ExplicitVisit(QueryDerivedTable node)
        {
            Console.WriteLine("Start ExplicitVisit(QueryDerivedTable)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(QueryDerivedTable)");
        }

        public override void ExplicitVisit(QueryExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(QueryExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(QueryExpression)");
        }

        public override void ExplicitVisit(QueryParenthesisExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(QueryParenthesisExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(QueryParenthesisExpression)");
        }

        public override void ExplicitVisit(QuerySpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(QuerySpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(QuerySpecification)");
        }

        public override void ExplicitVisit(QueueDelayAuditOption node)
        {
            Console.WriteLine("Start ExplicitVisit(QueueDelayAuditOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(QueueDelayAuditOption)");
        }

        public override void ExplicitVisit(QueueExecuteAsOption node)
        {
            Console.WriteLine("Start ExplicitVisit(QueueExecuteAsOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(QueueExecuteAsOption)");
        }

        public override void ExplicitVisit(QueueOption node)
        {
            Console.WriteLine("Start ExplicitVisit(QueueOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(QueueOption)");
        }

        public override void ExplicitVisit(QueueProcedureOption node)
        {
            Console.WriteLine("Start ExplicitVisit(QueueProcedureOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(QueueProcedureOption)");
        }

        public override void ExplicitVisit(QueueStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(QueueStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(QueueStatement)");
        }

        public override void ExplicitVisit(QueueStateOption node)
        {
            Console.WriteLine("Start ExplicitVisit(QueueStateOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(QueueStateOption)");
        }

        public override void ExplicitVisit(QueueValueOption node)
        {
            Console.WriteLine("Start ExplicitVisit(QueueValueOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(QueueValueOption)");
        }

        public override void ExplicitVisit(RaiseErrorLegacyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(RaiseErrorLegacyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RaiseErrorLegacyStatement)");
        }

        public override void ExplicitVisit(RaiseErrorStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(RaiseErrorStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RaiseErrorStatement)");
        }

        public override void ExplicitVisit(ReadOnlyForClause node)
        {
            Console.WriteLine("Start ExplicitVisit(ReadOnlyForClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ReadOnlyForClause)");
        }

        public override void ExplicitVisit(ReadTextStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(ReadTextStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ReadTextStatement)");
        }

        public override void ExplicitVisit(RealLiteral node)
        {
            Console.WriteLine("Start ExplicitVisit(RealLiteral)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RealLiteral)");
        }

        public override void ExplicitVisit(ReceiveStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(ReceiveStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ReceiveStatement)");
        }

        public override void ExplicitVisit(ReconfigureStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(ReconfigureStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ReconfigureStatement)");
        }

        public override void ExplicitVisit(RecoveryDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(RecoveryDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RecoveryDatabaseOption)");
        }

        public override void ExplicitVisit(RemoteServiceBindingOption node)
        {
            Console.WriteLine("Start ExplicitVisit(RemoteServiceBindingOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RemoteServiceBindingOption)");
        }

        public override void ExplicitVisit(RemoteServiceBindingStatementBase node)
        {
            Console.WriteLine("Start ExplicitVisit(RemoteServiceBindingStatementBase)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RemoteServiceBindingStatementBase)");
        }

        public override void ExplicitVisit(RenameAlterRoleAction node)
        {
            Console.WriteLine("Start ExplicitVisit(RenameAlterRoleAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RenameAlterRoleAction)");
        }

        public override void ExplicitVisit(ResourcePoolAffinitySpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(ResourcePoolAffinitySpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ResourcePoolAffinitySpecification)");
        }

        public override void ExplicitVisit(ResourcePoolParameter node)
        {
            Console.WriteLine("Start ExplicitVisit(ResourcePoolParameter)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ResourcePoolParameter)");
        }

        public override void ExplicitVisit(ResourcePoolStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(ResourcePoolStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ResourcePoolStatement)");
        }

        public override void ExplicitVisit(RestoreMasterKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(RestoreMasterKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RestoreMasterKeyStatement)");
        }

        public override void ExplicitVisit(RestoreOption node)
        {
            Console.WriteLine("Start ExplicitVisit(RestoreOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RestoreOption)");
        }

        public override void ExplicitVisit(RestoreServiceMasterKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(RestoreServiceMasterKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RestoreServiceMasterKeyStatement)");
        }

        public override void ExplicitVisit(RestoreStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(RestoreStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RestoreStatement)");
        }

        public override void ExplicitVisit(ResultColumnDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(ResultColumnDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ResultColumnDefinition)");
        }

        public override void ExplicitVisit(ResultSetDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(ResultSetDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ResultSetDefinition)");
        }

        public override void ExplicitVisit(ResultSetsExecuteOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ResultSetsExecuteOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ResultSetsExecuteOption)");
        }

        public override void ExplicitVisit(ReturnStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(ReturnStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ReturnStatement)");
        }

        public override void ExplicitVisit(RevertStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(RevertStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RevertStatement)");
        }

        public override void ExplicitVisit(RevokeStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(RevokeStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RevokeStatement)");
        }

        public override void ExplicitVisit(RevokeStatement80 node)
        {
            Console.WriteLine("Start ExplicitVisit(RevokeStatement80)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RevokeStatement80)");
        }

        public override void ExplicitVisit(RightFunctionCall node)
        {
            Console.WriteLine("Start ExplicitVisit(RightFunctionCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RightFunctionCall)");
        }

        public override void ExplicitVisit(RolePayloadOption node)
        {
            Console.WriteLine("Start ExplicitVisit(RolePayloadOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RolePayloadOption)");
        }

        public override void ExplicitVisit(RoleStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(RoleStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RoleStatement)");
        }

        public override void ExplicitVisit(RollbackTransactionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(RollbackTransactionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RollbackTransactionStatement)");
        }

        public override void ExplicitVisit(RollupGroupingSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(RollupGroupingSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RollupGroupingSpecification)");
        }

        public override void ExplicitVisit(RouteOption node)
        {
            Console.WriteLine("Start ExplicitVisit(RouteOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RouteOption)");
        }

        public override void ExplicitVisit(RouteStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(RouteStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RouteStatement)");
        }

        public override void ExplicitVisit(RowValue node)
        {
            Console.WriteLine("Start ExplicitVisit(RowValue)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(RowValue)");
        }

        public override void ExplicitVisit(SaveTransactionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SaveTransactionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SaveTransactionStatement)");
        }

        public override void ExplicitVisit(ScalarExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(ScalarExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ScalarExpression)");
        }

        public override void ExplicitVisit(ScalarExpressionDialogOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ScalarExpressionDialogOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ScalarExpressionDialogOption)");
        }

        public override void ExplicitVisit(ScalarExpressionRestoreOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ScalarExpressionRestoreOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ScalarExpressionRestoreOption)");
        }

        public override void ExplicitVisit(ScalarExpressionSequenceOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ScalarExpressionSequenceOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ScalarExpressionSequenceOption)");
        }

        public override void ExplicitVisit(ScalarExpressionSnippet node)
        {
            Console.WriteLine("Start ExplicitVisit(ScalarExpressionSnippet)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ScalarExpressionSnippet)");
        }

        public override void ExplicitVisit(ScalarFunctionReturnType node)
        {
            Console.WriteLine("Start ExplicitVisit(ScalarFunctionReturnType)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ScalarFunctionReturnType)");
        }

        public override void ExplicitVisit(ScalarSubquery node)
        {
            Console.WriteLine("Start ExplicitVisit(ScalarSubquery)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ScalarSubquery)");
        }

        public override void ExplicitVisit(SchemaDeclarationItem node)
        {
            Console.WriteLine("Start ExplicitVisit(SchemaDeclarationItem)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SchemaDeclarationItem)");
        }

        public override void ExplicitVisit(SchemaObjectFunctionTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(SchemaObjectFunctionTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SchemaObjectFunctionTableReference)");
        }

        public override void ExplicitVisit(SchemaObjectName node)
        {
            Console.WriteLine("Start ExplicitVisit(SchemaObjectName)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SchemaObjectName)");
        }

        public override void ExplicitVisit(SchemaObjectNameOrValueExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(SchemaObjectNameOrValueExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SchemaObjectNameOrValueExpression)");
        }

        public override void ExplicitVisit(SchemaObjectNameSnippet node)
        {
            Console.WriteLine("Start ExplicitVisit(SchemaObjectNameSnippet)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SchemaObjectNameSnippet)");
        }

        public override void ExplicitVisit(SchemaObjectResultSetDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(SchemaObjectResultSetDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SchemaObjectResultSetDefinition)");
        }

        public override void ExplicitVisit(SchemaPayloadOption node)
        {
            Console.WriteLine("Start ExplicitVisit(SchemaPayloadOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SchemaPayloadOption)");
        }

        public override void ExplicitVisit(SearchedCaseExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(SearchedCaseExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SearchedCaseExpression)");
        }

        public override void ExplicitVisit(SearchedWhenClause node)
        {
            Console.WriteLine("Start ExplicitVisit(SearchedWhenClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SearchedWhenClause)");
        }

        public override void ExplicitVisit(SearchPropertyListAction node)
        {
            Console.WriteLine("Start ExplicitVisit(SearchPropertyListAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SearchPropertyListAction)");
        }

        public override void ExplicitVisit(SearchPropertyListFullTextIndexOption node)
        {
            Console.WriteLine("Start ExplicitVisit(SearchPropertyListFullTextIndexOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SearchPropertyListFullTextIndexOption)");
        }

        public override void ExplicitVisit(SecondaryRoleReplicaOption node)
        {
            Console.WriteLine("Start ExplicitVisit(SecondaryRoleReplicaOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SecondaryRoleReplicaOption)");
        }

        public override void ExplicitVisit(SecurityElement80 node)
        {
            Console.WriteLine("Start ExplicitVisit(SecurityElement80)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SecurityElement80)");
        }

        public override void ExplicitVisit(SecurityPrincipal node)
        {
            Console.WriteLine("Start ExplicitVisit(SecurityPrincipal)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SecurityPrincipal)");
        }

        public override void ExplicitVisit(SecurityStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SecurityStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SecurityStatement)");
        }

        public override void ExplicitVisit(SecurityStatementBody80 node)
        {
            Console.WriteLine("Start ExplicitVisit(SecurityStatementBody80)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SecurityStatementBody80)");
        }

        public override void ExplicitVisit(SecurityTargetObject node)
        {
            Console.WriteLine("Start ExplicitVisit(SecurityTargetObject)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SecurityTargetObject)");
        }

        public override void ExplicitVisit(SecurityTargetObjectName node)
        {
            Console.WriteLine("Start ExplicitVisit(SecurityTargetObjectName)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SecurityTargetObjectName)");
        }

        public override void ExplicitVisit(SecurityUserClause80 node)
        {
            Console.WriteLine("Start ExplicitVisit(SecurityUserClause80)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SecurityUserClause80)");
        }

        public override void ExplicitVisit(SelectElement node)
        {
            Console.WriteLine("Start ExplicitVisit(SelectElement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SelectElement)");
        }

        public override void ExplicitVisit(SelectFunctionReturnType node)
        {
            Console.WriteLine("Start ExplicitVisit(SelectFunctionReturnType)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SelectFunctionReturnType)");
        }

        public override void ExplicitVisit(SelectInsertSource node)
        {
            Console.WriteLine("Start ExplicitVisit(SelectInsertSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SelectInsertSource)");
        }
        /*
        public override void ExplicitVisit(SelectiveXmlIndexPromotedPath node)
        {
            Console.WriteLine("Start ExplicitVisit(SelectiveXmlIndexPromotedPath)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SelectiveXmlIndexPromotedPath)");
        }
        */
        public override void ExplicitVisit(SelectScalarExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(SelectScalarExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SelectScalarExpression)");
        }

        public override void ExplicitVisit(SelectSetVariable node)
        {
            Console.WriteLine("Start ExplicitVisit(SelectSetVariable)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SelectSetVariable)");
        }

        public override void ExplicitVisit(SelectStarExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(SelectStarExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SelectStarExpression)");
        }

        public override void ExplicitVisit(SelectStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SelectStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SelectStatement)");
        }

        public override void ExplicitVisit(SelectStatementSnippet node)
        {
            Console.WriteLine("Start ExplicitVisit(SelectStatementSnippet)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SelectStatementSnippet)");
        }

        public override void ExplicitVisit(SemanticTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(SemanticTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SemanticTableReference)");
        }

        public override void ExplicitVisit(SendStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SendStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SendStatement)");
        }

        public override void ExplicitVisit(SequenceOption node)
        {
            Console.WriteLine("Start ExplicitVisit(SequenceOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SequenceOption)");
        }

        public override void ExplicitVisit(SequenceStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SequenceStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SequenceStatement)");
        }

        public override void ExplicitVisit(ServerAuditStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(ServerAuditStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ServerAuditStatement)");
        }

        public override void ExplicitVisit(ServiceContract node)
        {
            Console.WriteLine("Start ExplicitVisit(ServiceContract)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ServiceContract)");
        }

        public override void ExplicitVisit(SessionOption node)
        {
            Console.WriteLine("Start ExplicitVisit(SessionOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SessionOption)");
        }

        public override void ExplicitVisit(SessionTimeoutPayloadOption node)
        {
            Console.WriteLine("Start ExplicitVisit(SessionTimeoutPayloadOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SessionTimeoutPayloadOption)");
        }

        public override void ExplicitVisit(SetClause node)
        {
            Console.WriteLine("Start ExplicitVisit(SetClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetClause)");
        }

        public override void ExplicitVisit(SetCommand node)
        {
            Console.WriteLine("Start ExplicitVisit(SetCommand)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetCommand)");
        }

        public override void ExplicitVisit(SetCommandStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SetCommandStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetCommandStatement)");
        }

        public override void ExplicitVisit(SetErrorLevelStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SetErrorLevelStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetErrorLevelStatement)");
        }

        public override void ExplicitVisit(SetFipsFlaggerCommand node)
        {
            Console.WriteLine("Start ExplicitVisit(SetFipsFlaggerCommand)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetFipsFlaggerCommand)");
        }

        public override void ExplicitVisit(SetIdentityInsertStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SetIdentityInsertStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetIdentityInsertStatement)");
        }

        public override void ExplicitVisit(SetOffsetsStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SetOffsetsStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetOffsetsStatement)");
        }

        public override void ExplicitVisit(SetOnOffStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SetOnOffStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetOnOffStatement)");
        }

        public override void ExplicitVisit(SetRowCountStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SetRowCountStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetRowCountStatement)");
        }

        public override void ExplicitVisit(SetSearchPropertyListAlterFullTextIndexAction node)
        {
            Console.WriteLine("Start ExplicitVisit(SetSearchPropertyListAlterFullTextIndexAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetSearchPropertyListAlterFullTextIndexAction)");
        }

        public override void ExplicitVisit(SetStatisticsStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SetStatisticsStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetStatisticsStatement)");
        }

        public override void ExplicitVisit(SetStopListAlterFullTextIndexAction node)
        {
            Console.WriteLine("Start ExplicitVisit(SetStopListAlterFullTextIndexAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetStopListAlterFullTextIndexAction)");
        }

        public override void ExplicitVisit(SetTextSizeStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SetTextSizeStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetTextSizeStatement)");
        }

        public override void ExplicitVisit(SetTransactionIsolationLevelStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SetTransactionIsolationLevelStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetTransactionIsolationLevelStatement)");
        }

        public override void ExplicitVisit(SetUserStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SetUserStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetUserStatement)");
        }

        public override void ExplicitVisit(SetVariableStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SetVariableStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SetVariableStatement)");
        }

        public override void ExplicitVisit(ShutdownStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(ShutdownStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ShutdownStatement)");
        }

        public override void ExplicitVisit(SignatureStatementBase node)
        {
            Console.WriteLine("Start ExplicitVisit(SignatureStatementBase)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SignatureStatementBase)");
        }

        public override void ExplicitVisit(SimpleAlterFullTextIndexAction node)
        {
            Console.WriteLine("Start ExplicitVisit(SimpleAlterFullTextIndexAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SimpleAlterFullTextIndexAction)");
        }

        public override void ExplicitVisit(SimpleCaseExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(SimpleCaseExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SimpleCaseExpression)");
        }

        public override void ExplicitVisit(SimpleWhenClause node)
        {
            Console.WriteLine("Start ExplicitVisit(SimpleWhenClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SimpleWhenClause)");
        }

        public override void ExplicitVisit(SizeFileDeclarationOption node)
        {
            Console.WriteLine("Start ExplicitVisit(SizeFileDeclarationOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SizeFileDeclarationOption)");
        }

        public override void ExplicitVisit(SoapMethod node)
        {
            Console.WriteLine("Start ExplicitVisit(SoapMethod)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SoapMethod)");
        }

        public override void ExplicitVisit(SourceDeclaration node)
        {
            Console.WriteLine("Start ExplicitVisit(SourceDeclaration)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SourceDeclaration)");
        }

        public override void ExplicitVisit(SpatialIndexOption node)
        {
            Console.WriteLine("Start ExplicitVisit(SpatialIndexOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SpatialIndexOption)");
        }

        public override void ExplicitVisit(SpatialIndexRegularOption node)
        {
            Console.WriteLine("Start ExplicitVisit(SpatialIndexRegularOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SpatialIndexRegularOption)");
        }

        public override void ExplicitVisit(SqlCommandIdentifier node)
        {
            Console.WriteLine("Start ExplicitVisit(SqlCommandIdentifier)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SqlCommandIdentifier)");
        }

        public override void ExplicitVisit(SqlDataTypeReference node)
        {
            Console.WriteLine("Start ExplicitVisit(SqlDataTypeReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SqlDataTypeReference)");
        }

        public override void ExplicitVisit(StateAuditOption node)
        {
            Console.WriteLine("Start ExplicitVisit(StateAuditOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(StateAuditOption)");
        }

        public override void ExplicitVisit(StatementList node)
        {
            Console.WriteLine("Start ExplicitVisit(StatementList)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(StatementList)");
        }

        public override void ExplicitVisit(StatementListSnippet node)
        {
            Console.WriteLine("Start ExplicitVisit(StatementListSnippet)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(StatementListSnippet)");
        }

        public override void ExplicitVisit(StatementWithCtesAndXmlNamespaces node)
        {
            Console.WriteLine("Start ExplicitVisit(StatementWithCtesAndXmlNamespaces)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(StatementWithCtesAndXmlNamespaces)");
        }

        public override void ExplicitVisit(StatisticsOption node)
        {
            Console.WriteLine("Start ExplicitVisit(StatisticsOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(StatisticsOption)");
        }

        public override void ExplicitVisit(StopListFullTextIndexOption node)
        {
            Console.WriteLine("Start ExplicitVisit(StopListFullTextIndexOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(StopListFullTextIndexOption)");
        }

        public override void ExplicitVisit(StopRestoreOption node)
        {
            Console.WriteLine("Start ExplicitVisit(StopRestoreOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(StopRestoreOption)");
        }

        public override void ExplicitVisit(StringLiteral node)
        {
            Console.WriteLine("Start ExplicitVisit(StringLiteral)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(StringLiteral)");
        }

        public override void ExplicitVisit(SubqueryComparisonPredicate node)
        {
            Console.WriteLine("Start ExplicitVisit(SubqueryComparisonPredicate)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SubqueryComparisonPredicate)");
        }

        public override void ExplicitVisit(SymmetricKeyStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(SymmetricKeyStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(SymmetricKeyStatement)");
        }

        public override void ExplicitVisit(TableDataCompressionOption node)
        {
            Console.WriteLine("Start ExplicitVisit(TableDataCompressionOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TableDataCompressionOption)");
        }

        public override void ExplicitVisit(TableDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(TableDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TableDefinition)");
        }

        public override void ExplicitVisit(TableHint node)
        {
            Console.WriteLine("Start ExplicitVisit(TableHint)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TableHint)");
        }

        public override void ExplicitVisit(TableHintsOptimizerHint node)
        {
            Console.WriteLine("Start ExplicitVisit(TableHintsOptimizerHint)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TableHintsOptimizerHint)");
        }

        public override void ExplicitVisit(TableOption node)
        {
            Console.WriteLine("Start ExplicitVisit(TableOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TableOption)");
        }

        public override void ExplicitVisit(TableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(TableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TableReference)");
        }

        public override void ExplicitVisit(TableReferenceWithAlias node)
        {
            Console.WriteLine("Start ExplicitVisit(TableReferenceWithAlias)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TableReferenceWithAlias)");
        }

        public override void ExplicitVisit(TableReferenceWithAliasAndColumns node)
        {
            Console.WriteLine("Start ExplicitVisit(TableReferenceWithAliasAndColumns)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TableReferenceWithAliasAndColumns)");
        }

        public override void ExplicitVisit(TableSampleClause node)
        {
            Console.WriteLine("Start ExplicitVisit(TableSampleClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TableSampleClause)");
        }

        public override void ExplicitVisit(TableValuedFunctionReturnType node)
        {
            Console.WriteLine("Start ExplicitVisit(TableValuedFunctionReturnType)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TableValuedFunctionReturnType)");
        }

        public override void ExplicitVisit(TargetDeclaration node)
        {
            Console.WriteLine("Start ExplicitVisit(TargetDeclaration)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TargetDeclaration)");
        }

        public override void ExplicitVisit(TargetRecoveryTimeDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(TargetRecoveryTimeDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TargetRecoveryTimeDatabaseOption)");
        }

        public override void ExplicitVisit(TextModificationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(TextModificationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TextModificationStatement)");
        }

        public override void ExplicitVisit(ThrowStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(ThrowStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ThrowStatement)");
        }

        public override void ExplicitVisit(TopRowFilter node)
        {
            Console.WriteLine("Start ExplicitVisit(TopRowFilter)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TopRowFilter)");
        }

        public override void ExplicitVisit(TransactionStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(TransactionStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TransactionStatement)");
        }

        public override void ExplicitVisit(TriggerAction node)
        {
            Console.WriteLine("Start ExplicitVisit(TriggerAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TriggerAction)");
        }

        public override void ExplicitVisit(TriggerObject node)
        {
            Console.WriteLine("Start ExplicitVisit(TriggerObject)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TriggerObject)");
        }

        public override void ExplicitVisit(TriggerOption node)
        {
            Console.WriteLine("Start ExplicitVisit(TriggerOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TriggerOption)");
        }

        public override void ExplicitVisit(TriggerStatementBody node)
        {
            Console.WriteLine("Start ExplicitVisit(TriggerStatementBody)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TriggerStatementBody)");
        }

        public override void ExplicitVisit(TruncateTableStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(TruncateTableStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TruncateTableStatement)");
        }

        public override void ExplicitVisit(TryCastCall node)
        {
            Console.WriteLine("Start ExplicitVisit(TryCastCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TryCastCall)");
        }

        public override void ExplicitVisit(TryCatchStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(TryCatchStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TryCatchStatement)");
        }

        public override void ExplicitVisit(TryConvertCall node)
        {
            Console.WriteLine("Start ExplicitVisit(TryConvertCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TryConvertCall)");
        }

        public override void ExplicitVisit(TryParseCall node)
        {
            Console.WriteLine("Start ExplicitVisit(TryParseCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TryParseCall)");
        }

        public override void ExplicitVisit(TSEqualCall node)
        {
            Console.WriteLine("Start ExplicitVisit(TSEqualCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TSEqualCall)");
        }

        public override void ExplicitVisit(TSqlBatch node)
        {
            Console.WriteLine("Start ExplicitVisit(TSqlBatch)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TSqlBatch)");
        }

        public override void ExplicitVisit(TSqlFragmentSnippet node)
        {
            Console.WriteLine("Start ExplicitVisit(TSqlFragmentSnippet)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TSqlFragmentSnippet)");
        }

        public override void ExplicitVisit(TSqlScript node)
        {
            Console.WriteLine("Start ExplicitVisit(TSqlScript)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TSqlScript)");
        }

        public override void ExplicitVisit(TSqlStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(TSqlStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TSqlStatement)");
        }

        public override void ExplicitVisit(TSqlStatementSnippet node)
        {
            Console.WriteLine("Start ExplicitVisit(TSqlStatementSnippet)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(TSqlStatementSnippet)");
        }

        public override void ExplicitVisit(UnaryExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(UnaryExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UnaryExpression)");
        }

        public override void ExplicitVisit(UniqueConstraintDefinition node)
        {
            Console.WriteLine("Start ExplicitVisit(UniqueConstraintDefinition)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UniqueConstraintDefinition)");
        }

        public override void ExplicitVisit(UnpivotedTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(UnpivotedTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UnpivotedTableReference)");
        }

        public override void ExplicitVisit(UnqualifiedJoin node)
        {
            Console.WriteLine("Start ExplicitVisit(UnqualifiedJoin)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UnqualifiedJoin)");
        }

        public override void ExplicitVisit(UpdateCall node)
        {
            Console.WriteLine("Start ExplicitVisit(UpdateCall)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UpdateCall)");
        }

        public override void ExplicitVisit(UpdateDeleteSpecificationBase node)
        {
            Console.WriteLine("Start ExplicitVisit(UpdateDeleteSpecificationBase)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UpdateDeleteSpecificationBase)");
        }

        public override void ExplicitVisit(UpdateForClause node)
        {
            Console.WriteLine("Start ExplicitVisit(UpdateForClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UpdateForClause)");
        }

        public override void ExplicitVisit(UpdateMergeAction node)
        {
            Console.WriteLine("Start ExplicitVisit(UpdateMergeAction)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UpdateMergeAction)");
        }

        public override void ExplicitVisit(UpdateSpecification node)
        {
            Console.WriteLine("Start ExplicitVisit(UpdateSpecification)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UpdateSpecification)");
        }

        public override void ExplicitVisit(UpdateStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(UpdateStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UpdateStatement)");
        }

        public override void ExplicitVisit(UpdateStatisticsStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(UpdateStatisticsStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UpdateStatisticsStatement)");
        }

        public override void ExplicitVisit(UpdateTextStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(UpdateTextStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UpdateTextStatement)");
        }

        public override void ExplicitVisit(UseFederationStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(UseFederationStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UseFederationStatement)");
        }

        public override void ExplicitVisit(UserDataTypeReference node)
        {
            Console.WriteLine("Start ExplicitVisit(UserDataTypeReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UserDataTypeReference)");
        }

        public override void ExplicitVisit(UserDefinedTypeCallTarget node)
        {
            Console.WriteLine("Start ExplicitVisit(UserDefinedTypeCallTarget)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UserDefinedTypeCallTarget)");
        }

        public override void ExplicitVisit(UserDefinedTypePropertyAccess node)
        {
            Console.WriteLine("Start ExplicitVisit(UserDefinedTypePropertyAccess)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UserDefinedTypePropertyAccess)");
        }

        public override void ExplicitVisit(UserLoginOption node)
        {
            Console.WriteLine("Start ExplicitVisit(UserLoginOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UserLoginOption)");
        }

        public override void ExplicitVisit(UserRemoteServiceBindingOption node)
        {
            Console.WriteLine("Start ExplicitVisit(UserRemoteServiceBindingOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UserRemoteServiceBindingOption)");
        }

        public override void ExplicitVisit(UserStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(UserStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UserStatement)");
        }

        public override void ExplicitVisit(UseStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(UseStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(UseStatement)");
        }

        public override void ExplicitVisit(ValueExpression node)
        {
            Console.WriteLine("Start ExplicitVisit(ValueExpression)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ValueExpression)");
        }

        public override void ExplicitVisit(ValuesInsertSource node)
        {
            Console.WriteLine("Start ExplicitVisit(ValuesInsertSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ValuesInsertSource)");
        }

        public override void ExplicitVisit(VariableMethodCallTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(VariableMethodCallTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(VariableMethodCallTableReference)");
        }

        public override void ExplicitVisit(VariableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(VariableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(VariableReference)");
        }

        public override void ExplicitVisit(VariableTableReference node)
        {
            Console.WriteLine("Start ExplicitVisit(VariableTableReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(VariableTableReference)");
        }

        public override void ExplicitVisit(VariableValuePair node)
        {
            Console.WriteLine("Start ExplicitVisit(VariableValuePair)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(VariableValuePair)");
        }

        public override void ExplicitVisit(ViewOption node)
        {
            Console.WriteLine("Start ExplicitVisit(ViewOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ViewOption)");
        }

        public override void ExplicitVisit(ViewStatementBody node)
        {
            Console.WriteLine("Start ExplicitVisit(ViewStatementBody)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(ViewStatementBody)");
        }

        public override void ExplicitVisit(WaitForStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(WaitForStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WaitForStatement)");
        }

        public override void ExplicitVisit(WaitForSupportedStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(WaitForSupportedStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WaitForSupportedStatement)");
        }

        public override void ExplicitVisit(WhenClause node)
        {
            Console.WriteLine("Start ExplicitVisit(WhenClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WhenClause)");
        }

        public override void ExplicitVisit(WhereClause node)
        {
            Console.WriteLine("Start ExplicitVisit(WhereClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WhereClause)");
        }

        public override void ExplicitVisit(WhileStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(WhileStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WhileStatement)");
        }

        public override void ExplicitVisit(WindowDelimiter node)
        {
            Console.WriteLine("Start ExplicitVisit(WindowDelimiter)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WindowDelimiter)");
        }

        public override void ExplicitVisit(WindowFrameClause node)
        {
            Console.WriteLine("Start ExplicitVisit(WindowFrameClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WindowFrameClause)");
        }

        public override void ExplicitVisit(WindowsCreateLoginSource node)
        {
            Console.WriteLine("Start ExplicitVisit(WindowsCreateLoginSource)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WindowsCreateLoginSource)");
        }

        public override void ExplicitVisit(WithCtesAndXmlNamespaces node)
        {
            Console.WriteLine("Start ExplicitVisit(WithCtesAndXmlNamespaces)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WithCtesAndXmlNamespaces)");
        }

        public override void ExplicitVisit(WithinGroupClause node)
        {
            Console.WriteLine("Start ExplicitVisit(WithinGroupClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WithinGroupClause)");
        }

        public override void ExplicitVisit(WitnessDatabaseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(WitnessDatabaseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WitnessDatabaseOption)");
        }

        public override void ExplicitVisit(WorkloadGroupImportanceParameter node)
        {
            Console.WriteLine("Start ExplicitVisit(WorkloadGroupImportanceParameter)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WorkloadGroupImportanceParameter)");
        }

        public override void ExplicitVisit(WorkloadGroupParameter node)
        {
            Console.WriteLine("Start ExplicitVisit(WorkloadGroupParameter)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WorkloadGroupParameter)");
        }

        public override void ExplicitVisit(WorkloadGroupResourceParameter node)
        {
            Console.WriteLine("Start ExplicitVisit(WorkloadGroupResourceParameter)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WorkloadGroupResourceParameter)");
        }

        public override void ExplicitVisit(WorkloadGroupStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(WorkloadGroupStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WorkloadGroupStatement)");
        }

        public override void ExplicitVisit(WriteTextStatement node)
        {
            Console.WriteLine("Start ExplicitVisit(WriteTextStatement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WriteTextStatement)");
        }

        public override void ExplicitVisit(WsdlPayloadOption node)
        {
            Console.WriteLine("Start ExplicitVisit(WsdlPayloadOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(WsdlPayloadOption)");
        }

        public override void ExplicitVisit(XmlDataTypeReference node)
        {
            Console.WriteLine("Start ExplicitVisit(XmlDataTypeReference)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(XmlDataTypeReference)");
        }

        public override void ExplicitVisit(XmlForClause node)
        {
            Console.WriteLine("Start ExplicitVisit(XmlForClause)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(XmlForClause)");
        }

        public override void ExplicitVisit(XmlForClauseOption node)
        {
            Console.WriteLine("Start ExplicitVisit(XmlForClauseOption)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(XmlForClauseOption)");
        }

        public override void ExplicitVisit(XmlNamespaces node)
        {
            Console.WriteLine("Start ExplicitVisit(XmlNamespaces)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(XmlNamespaces)");
        }

        public override void ExplicitVisit(XmlNamespacesAliasElement node)
        {
            Console.WriteLine("Start ExplicitVisit(XmlNamespacesAliasElement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(XmlNamespacesAliasElement)");
        }

        public override void ExplicitVisit(XmlNamespacesDefaultElement node)
        {
            Console.WriteLine("Start ExplicitVisit(XmlNamespacesDefaultElement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(XmlNamespacesDefaultElement)");
        }

        public override void ExplicitVisit(XmlNamespacesElement node)
        {
            Console.WriteLine("Start ExplicitVisit(XmlNamespacesElement)");
            base.ExplicitVisit(node);
            Console.WriteLine("End ExplicitVisit(XmlNamespacesElement)");
        }

        public override void Visit(AddAlterFullTextIndexAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AddAlterFullTextIndexAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(AddAlterFullTextIndexAction)");
        }

        public override void Visit(AddFileSpec node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AddFileSpec)");
            base.Visit(node);
            Console.WriteLine("End Visit(AddFileSpec)");
        }

        public override void Visit(AddMemberAlterRoleAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AddMemberAlterRoleAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(AddMemberAlterRoleAction)");
        }

        public override void Visit(AddSearchPropertyListAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AddSearchPropertyListAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(AddSearchPropertyListAction)");
        }

        public override void Visit(AddSignatureStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AddSignatureStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AddSignatureStatement)");
        }

        public override void Visit(AdHocDataSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AdHocDataSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(AdHocDataSource)");
        }

        public override void Visit(AdHocTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AdHocTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(AdHocTableReference)");
        }

        public override void Visit(AlgorithmKeyOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlgorithmKeyOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlgorithmKeyOption)");
        }

        public override void Visit(AlterApplicationRoleStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterApplicationRoleStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterApplicationRoleStatement)");
        }

        public override void Visit(AlterAssemblyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterAssemblyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterAssemblyStatement)");
        }

        public override void Visit(AlterAsymmetricKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterAsymmetricKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterAsymmetricKeyStatement)");
        }

        public override void Visit(AlterAuthorizationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterAuthorizationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterAuthorizationStatement)");
        }

        public override void Visit(AlterAvailabilityGroupAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterAvailabilityGroupAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterAvailabilityGroupAction)");
        }

        public override void Visit(AlterAvailabilityGroupFailoverAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterAvailabilityGroupFailoverAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterAvailabilityGroupFailoverAction)");
        }

        public override void Visit(AlterAvailabilityGroupFailoverOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterAvailabilityGroupFailoverOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterAvailabilityGroupFailoverOption)");
        }

        public override void Visit(AlterAvailabilityGroupStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterAvailabilityGroupStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterAvailabilityGroupStatement)");
        }

        public override void Visit(AlterBrokerPriorityStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterBrokerPriorityStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterBrokerPriorityStatement)");
        }

        public override void Visit(AlterCertificateStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterCertificateStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterCertificateStatement)");
        }

        public override void Visit(AlterColumnAlterFullTextIndexAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterColumnAlterFullTextIndexAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterColumnAlterFullTextIndexAction)");
        }

        public override void Visit(AlterCreateEndpointStatementBase node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterCreateEndpointStatementBase)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterCreateEndpointStatementBase)");
        }

        public override void Visit(AlterCreateServiceStatementBase node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterCreateServiceStatementBase)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterCreateServiceStatementBase)");
        }

        public override void Visit(AlterCredentialStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterCredentialStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterCredentialStatement)");
        }

        public override void Visit(AlterCryptographicProviderStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterCryptographicProviderStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterCryptographicProviderStatement)");
        }

        public override void Visit(AlterDatabaseAddFileGroupStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseAddFileGroupStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseAddFileGroupStatement)");
        }

        public override void Visit(AlterDatabaseAddFileStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseAddFileStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseAddFileStatement)");
        }

        public override void Visit(AlterDatabaseAuditSpecificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseAuditSpecificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseAuditSpecificationStatement)");
        }

        public override void Visit(AlterDatabaseCollateStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseCollateStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseCollateStatement)");
        }

        public override void Visit(AlterDatabaseEncryptionKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseEncryptionKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseEncryptionKeyStatement)");
        }

        public override void Visit(AlterDatabaseModifyFileGroupStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseModifyFileGroupStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseModifyFileGroupStatement)");
        }

        public override void Visit(AlterDatabaseModifyFileStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseModifyFileStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseModifyFileStatement)");
        }

        public override void Visit(AlterDatabaseModifyNameStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseModifyNameStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseModifyNameStatement)");
        }

        public override void Visit(AlterDatabaseRebuildLogStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseRebuildLogStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseRebuildLogStatement)");
        }

        public override void Visit(AlterDatabaseRemoveFileGroupStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseRemoveFileGroupStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseRemoveFileGroupStatement)");
        }

        public override void Visit(AlterDatabaseRemoveFileStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseRemoveFileStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseRemoveFileStatement)");
        }

        public override void Visit(AlterDatabaseSetStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseSetStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseSetStatement)");
        }

        public override void Visit(AlterDatabaseStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseStatement)");
        }

        public override void Visit(AlterDatabaseTermination node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterDatabaseTermination)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterDatabaseTermination)");
        }

        public override void Visit(AlterEndpointStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterEndpointStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterEndpointStatement)");
        }

        public override void Visit(AlterEventSessionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterEventSessionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterEventSessionStatement)");
        }

        public override void Visit(AlterFederationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterFederationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterFederationStatement)");
        }

        public override void Visit(AlterFullTextCatalogStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterFullTextCatalogStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterFullTextCatalogStatement)");
        }

        public override void Visit(AlterFullTextIndexAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterFullTextIndexAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterFullTextIndexAction)");
        }

        public override void Visit(AlterFullTextIndexStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterFullTextIndexStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterFullTextIndexStatement)");
        }

        public override void Visit(AlterFullTextStopListStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterFullTextStopListStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterFullTextStopListStatement)");
        }

        public override void Visit(AlterFunctionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterFunctionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterFunctionStatement)");
        }

        public override void Visit(AlterIndexStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterIndexStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterIndexStatement)");
        }

        public override void Visit(AlterLoginAddDropCredentialStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterLoginAddDropCredentialStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterLoginAddDropCredentialStatement)");
        }

        public override void Visit(AlterLoginEnableDisableStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterLoginEnableDisableStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterLoginEnableDisableStatement)");
        }

        public override void Visit(AlterLoginOptionsStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterLoginOptionsStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterLoginOptionsStatement)");
        }

        public override void Visit(AlterLoginStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterLoginStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterLoginStatement)");
        }

        public override void Visit(AlterMasterKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterMasterKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterMasterKeyStatement)");
        }

        public override void Visit(AlterMessageTypeStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterMessageTypeStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterMessageTypeStatement)");
        }

        public override void Visit(AlterPartitionFunctionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterPartitionFunctionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterPartitionFunctionStatement)");
        }

        public override void Visit(AlterPartitionSchemeStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterPartitionSchemeStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterPartitionSchemeStatement)");
        }

        public override void Visit(AlterProcedureStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterProcedureStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterProcedureStatement)");
        }

        public override void Visit(AlterQueueStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterQueueStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterQueueStatement)");
        }

        public override void Visit(AlterRemoteServiceBindingStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterRemoteServiceBindingStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterRemoteServiceBindingStatement)");
        }

        public override void Visit(AlterResourceGovernorStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterResourceGovernorStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterResourceGovernorStatement)");
        }

        public override void Visit(AlterResourcePoolStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterResourcePoolStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterResourcePoolStatement)");
        }

        public override void Visit(AlterRoleAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterRoleAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterRoleAction)");
        }

        public override void Visit(AlterRoleStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterRoleStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterRoleStatement)");
        }

        public override void Visit(AlterRouteStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterRouteStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterRouteStatement)");
        }

        public override void Visit(AlterSchemaStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterSchemaStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterSchemaStatement)");
        }

        public override void Visit(AlterSearchPropertyListStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterSearchPropertyListStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterSearchPropertyListStatement)");
        }

        public override void Visit(AlterSequenceStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterSequenceStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterSequenceStatement)");
        }

        public override void Visit(AlterServerAuditSpecificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterServerAuditSpecificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterServerAuditSpecificationStatement)");
        }

        public override void Visit(AlterServerAuditStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterServerAuditStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterServerAuditStatement)");
        }

        public override void Visit(AlterServerConfigurationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterServerConfigurationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterServerConfigurationStatement)");
        }

        public override void Visit(AlterServerRoleStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterServerRoleStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterServerRoleStatement)");
        }

        public override void Visit(AlterServiceMasterKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterServiceMasterKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterServiceMasterKeyStatement)");
        }

        public override void Visit(AlterServiceStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterServiceStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterServiceStatement)");
        }

        public override void Visit(AlterSymmetricKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterSymmetricKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterSymmetricKeyStatement)");
        }

        public override void Visit(AlterTableAddTableElementStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterTableAddTableElementStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterTableAddTableElementStatement)");
        }

        public override void Visit(AlterTableAlterColumnStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterTableAlterColumnStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterTableAlterColumnStatement)");
        }

        public override void Visit(AlterTableChangeTrackingModificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterTableChangeTrackingModificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterTableChangeTrackingModificationStatement)");
        }

        public override void Visit(AlterTableConstraintModificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterTableConstraintModificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterTableConstraintModificationStatement)");
        }

        public override void Visit(AlterTableDropTableElement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterTableDropTableElement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterTableDropTableElement)");
        }

        public override void Visit(AlterTableDropTableElementStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterTableDropTableElementStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterTableDropTableElementStatement)");
        }

        public override void Visit(AlterTableFileTableNamespaceStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterTableFileTableNamespaceStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterTableFileTableNamespaceStatement)");
        }

        public override void Visit(AlterTableRebuildStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterTableRebuildStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterTableRebuildStatement)");
        }

        public override void Visit(AlterTableSetStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterTableSetStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterTableSetStatement)");
        }

        public override void Visit(AlterTableStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterTableStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterTableStatement)");
        }

        public override void Visit(AlterTableSwitchStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterTableSwitchStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterTableSwitchStatement)");
        }

        public override void Visit(AlterTableTriggerModificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterTableTriggerModificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterTableTriggerModificationStatement)");
        }

        public override void Visit(AlterTriggerStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterTriggerStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterTriggerStatement)");
        }

        public override void Visit(AlterUserStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterUserStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterUserStatement)");
        }

        public override void Visit(AlterViewStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterViewStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterViewStatement)");
        }

        public override void Visit(AlterWorkloadGroupStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterWorkloadGroupStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterWorkloadGroupStatement)");
        }

        public override void Visit(AlterXmlSchemaCollectionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AlterXmlSchemaCollectionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AlterXmlSchemaCollectionStatement)");
        }

        public override void Visit(ApplicationRoleOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ApplicationRoleOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ApplicationRoleOption)");
        }

        public override void Visit(ApplicationRoleStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ApplicationRoleStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(ApplicationRoleStatement)");
        }

        public override void Visit(AssemblyEncryptionSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AssemblyEncryptionSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(AssemblyEncryptionSource)");
        }

        public override void Visit(AssemblyName node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AssemblyName)");
            base.Visit(node);
            Console.WriteLine("End Visit(AssemblyName)");
        }

        public override void Visit(AssemblyOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AssemblyOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(AssemblyOption)");
        }

        public override void Visit(AssemblyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AssemblyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AssemblyStatement)");
        }

        public override void Visit(AssignmentSetClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AssignmentSetClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(AssignmentSetClause)");
        }

        public override void Visit(AsymmetricKeyCreateLoginSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AsymmetricKeyCreateLoginSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(AsymmetricKeyCreateLoginSource)");
        }

        public override void Visit(AuditActionGroupReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AuditActionGroupReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(AuditActionGroupReference)");
        }

        public override void Visit(AuditActionSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AuditActionSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(AuditActionSpecification)");
        }

        public override void Visit(AuditGuidAuditOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AuditGuidAuditOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(AuditGuidAuditOption)");
        }

        public override void Visit(AuditOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AuditOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(AuditOption)");
        }

        public override void Visit(AuditSpecificationDetail node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AuditSpecificationDetail)");
            base.Visit(node);
            Console.WriteLine("End Visit(AuditSpecificationDetail)");
        }

        public override void Visit(AuditSpecificationPart node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AuditSpecificationPart)");
            base.Visit(node);
            Console.WriteLine("End Visit(AuditSpecificationPart)");
        }

        public override void Visit(AuditSpecificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AuditSpecificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AuditSpecificationStatement)");
        }

        public override void Visit(AuditTarget node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AuditTarget)");
            base.Visit(node);
            Console.WriteLine("End Visit(AuditTarget)");
        }

        public override void Visit(AuditTargetOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AuditTargetOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(AuditTargetOption)");
        }

        public override void Visit(AuthenticationEndpointProtocolOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AuthenticationEndpointProtocolOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(AuthenticationEndpointProtocolOption)");
        }

        public override void Visit(AuthenticationPayloadOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AuthenticationPayloadOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(AuthenticationPayloadOption)");
        }

        public override void Visit(AutoCleanupChangeTrackingOptionDetail node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AutoCleanupChangeTrackingOptionDetail)");
            base.Visit(node);
            Console.WriteLine("End Visit(AutoCleanupChangeTrackingOptionDetail)");
        }

        public override void Visit(AvailabilityGroupOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AvailabilityGroupOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(AvailabilityGroupOption)");
        }

        public override void Visit(AvailabilityGroupStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AvailabilityGroupStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(AvailabilityGroupStatement)");
        }

        public override void Visit(AvailabilityModeReplicaOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AvailabilityModeReplicaOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(AvailabilityModeReplicaOption)");
        }

        public override void Visit(AvailabilityReplica node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AvailabilityReplica)");
            base.Visit(node);
            Console.WriteLine("End Visit(AvailabilityReplica)");
        }

        public override void Visit(AvailabilityReplicaOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(AvailabilityReplicaOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(AvailabilityReplicaOption)");
        }

        public override void Visit(BackupCertificateStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BackupCertificateStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(BackupCertificateStatement)");
        }

        public override void Visit(BackupDatabaseStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BackupDatabaseStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(BackupDatabaseStatement)");
        }

        public override void Visit(BackupMasterKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BackupMasterKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(BackupMasterKeyStatement)");
        }

        public override void Visit(BackupOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BackupOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(BackupOption)");
        }

        public override void Visit(BackupRestoreFileInfo node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BackupRestoreFileInfo)");
            base.Visit(node);
            Console.WriteLine("End Visit(BackupRestoreFileInfo)");
        }

        public override void Visit(BackupRestoreMasterKeyStatementBase node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BackupRestoreMasterKeyStatementBase)");
            base.Visit(node);
            Console.WriteLine("End Visit(BackupRestoreMasterKeyStatementBase)");
        }

        public override void Visit(BackupServiceMasterKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BackupServiceMasterKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(BackupServiceMasterKeyStatement)");
        }

        public override void Visit(BackupStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BackupStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(BackupStatement)");
        }

        public override void Visit(BackupTransactionLogStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BackupTransactionLogStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(BackupTransactionLogStatement)");
        }

        public override void Visit(BackwardsCompatibleDropIndexClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BackwardsCompatibleDropIndexClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(BackwardsCompatibleDropIndexClause)");
        }

        public override void Visit(BeginConversationTimerStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BeginConversationTimerStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(BeginConversationTimerStatement)");
        }

        public override void Visit(BeginDialogStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BeginDialogStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(BeginDialogStatement)");
        }

        public override void Visit(BeginEndBlockStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BeginEndBlockStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(BeginEndBlockStatement)");
        }

        public override void Visit(BeginTransactionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BeginTransactionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(BeginTransactionStatement)");
        }

        public override void Visit(BinaryExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BinaryExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(BinaryExpression)");
        }

        public override void Visit(BinaryLiteral node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BinaryLiteral)");
            base.Visit(node);
            Console.WriteLine("End Visit(BinaryLiteral)");
        }

        public override void Visit(BinaryQueryExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BinaryQueryExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(BinaryQueryExpression)");
        }

        public override void Visit(BooleanBinaryExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BooleanBinaryExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(BooleanBinaryExpression)");
        }

        public override void Visit(BooleanComparisonExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BooleanComparisonExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(BooleanComparisonExpression)");
        }

        public override void Visit(BooleanExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BooleanExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(BooleanExpression)");
        }

        public override void Visit(BooleanExpressionSnippet node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BooleanExpressionSnippet)");
            base.Visit(node);
            Console.WriteLine("End Visit(BooleanExpressionSnippet)");
        }

        public override void Visit(BooleanIsNullExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BooleanIsNullExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(BooleanIsNullExpression)");
        }

        public override void Visit(BooleanNotExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BooleanNotExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(BooleanNotExpression)");
        }

        public override void Visit(BooleanParenthesisExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BooleanParenthesisExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(BooleanParenthesisExpression)");
        }

        public override void Visit(BooleanTernaryExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BooleanTernaryExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(BooleanTernaryExpression)");
        }

        public override void Visit(BoundingBoxParameter node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BoundingBoxParameter)");
            base.Visit(node);
            Console.WriteLine("End Visit(BoundingBoxParameter)");
        }

        public override void Visit(BoundingBoxSpatialIndexOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BoundingBoxSpatialIndexOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(BoundingBoxSpatialIndexOption)");
        }

        public override void Visit(BreakStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BreakStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(BreakStatement)");
        }

        public override void Visit(BrokerPriorityParameter node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BrokerPriorityParameter)");
            base.Visit(node);
            Console.WriteLine("End Visit(BrokerPriorityParameter)");
        }

        public override void Visit(BrokerPriorityStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BrokerPriorityStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(BrokerPriorityStatement)");
        }

        public override void Visit(BrowseForClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BrowseForClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(BrowseForClause)");
        }

        public override void Visit(BuiltInFunctionTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BuiltInFunctionTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(BuiltInFunctionTableReference)");
        }

        public override void Visit(BulkInsertBase node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BulkInsertBase)");
            base.Visit(node);
            Console.WriteLine("End Visit(BulkInsertBase)");
        }

        public override void Visit(BulkInsertOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BulkInsertOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(BulkInsertOption)");
        }

        public override void Visit(BulkInsertStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BulkInsertStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(BulkInsertStatement)");
        }

        public override void Visit(BulkOpenRowset node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(BulkOpenRowset)");
            base.Visit(node);
            Console.WriteLine("End Visit(BulkOpenRowset)");
        }

        public override void Visit(CallTarget node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CallTarget)");
            base.Visit(node);
            Console.WriteLine("End Visit(CallTarget)");
        }

        public override void Visit(CaseExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CaseExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(CaseExpression)");
        }

        public override void Visit(CastCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CastCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(CastCall)");
        }

        public override void Visit(CellsPerObjectSpatialIndexOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CellsPerObjectSpatialIndexOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(CellsPerObjectSpatialIndexOption)");
        }

        public override void Visit(CertificateCreateLoginSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CertificateCreateLoginSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(CertificateCreateLoginSource)");
        }

        public override void Visit(CertificateOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CertificateOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(CertificateOption)");
        }

        public override void Visit(CertificateStatementBase node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CertificateStatementBase)");
            base.Visit(node);
            Console.WriteLine("End Visit(CertificateStatementBase)");
        }

        public override void Visit(ChangeRetentionChangeTrackingOptionDetail node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ChangeRetentionChangeTrackingOptionDetail)");
            base.Visit(node);
            Console.WriteLine("End Visit(ChangeRetentionChangeTrackingOptionDetail)");
        }

        public override void Visit(ChangeTableChangesTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ChangeTableChangesTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(ChangeTableChangesTableReference)");
        }

        public override void Visit(ChangeTableVersionTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ChangeTableVersionTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(ChangeTableVersionTableReference)");
        }

        public override void Visit(ChangeTrackingDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ChangeTrackingDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ChangeTrackingDatabaseOption)");
        }

        public override void Visit(ChangeTrackingFullTextIndexOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ChangeTrackingFullTextIndexOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ChangeTrackingFullTextIndexOption)");
        }

        public override void Visit(ChangeTrackingOptionDetail node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ChangeTrackingOptionDetail)");
            base.Visit(node);
            Console.WriteLine("End Visit(ChangeTrackingOptionDetail)");
        }

        public override void Visit(CharacterSetPayloadOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CharacterSetPayloadOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(CharacterSetPayloadOption)");
        }

        public override void Visit(CheckConstraintDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CheckConstraintDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(CheckConstraintDefinition)");
        }

        public override void Visit(CheckpointStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CheckpointStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CheckpointStatement)");
        }

        public override void Visit(ChildObjectName node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ChildObjectName)");
            base.Visit(node);
            Console.WriteLine("End Visit(ChildObjectName)");
        }

        public override void Visit(CloseCursorStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CloseCursorStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CloseCursorStatement)");
        }

        public override void Visit(CloseMasterKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CloseMasterKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CloseMasterKeyStatement)");
        }

        public override void Visit(CloseSymmetricKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CloseSymmetricKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CloseSymmetricKeyStatement)");
        }

        public override void Visit(CoalesceExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CoalesceExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(CoalesceExpression)");
        }

        public override void Visit(ColumnDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ColumnDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(ColumnDefinition)");
        }

        public override void Visit(ColumnDefinitionBase node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ColumnDefinitionBase)");
            base.Visit(node);
            Console.WriteLine("End Visit(ColumnDefinitionBase)");
        }

        public override void Visit(ColumnReferenceExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ColumnReferenceExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(ColumnReferenceExpression)");
        }

        public override void Visit(ColumnStorageOptions node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ColumnStorageOptions)");
            base.Visit(node);
            Console.WriteLine("End Visit(ColumnStorageOptions)");
        }

        public override void Visit(ColumnWithSortOrder node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ColumnWithSortOrder)");
            base.Visit(node);
            Console.WriteLine("End Visit(ColumnWithSortOrder)");
        }

        public override void Visit(CommandSecurityElement80 node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CommandSecurityElement80)");
            base.Visit(node);
            Console.WriteLine("End Visit(CommandSecurityElement80)");
        }

        public override void Visit(CommitTransactionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CommitTransactionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CommitTransactionStatement)");
        }

        public override void Visit(CommonTableExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CommonTableExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(CommonTableExpression)");
        }

        public override void Visit(CompositeGroupingSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CompositeGroupingSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(CompositeGroupingSpecification)");
        }

        public override void Visit(CompressionEndpointProtocolOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CompressionEndpointProtocolOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(CompressionEndpointProtocolOption)");
        }

        public override void Visit(CompressionPartitionRange node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CompressionPartitionRange)");
            base.Visit(node);
            Console.WriteLine("End Visit(CompressionPartitionRange)");
        }

        public override void Visit(ComputeClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ComputeClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(ComputeClause)");
        }

        public override void Visit(ComputeFunction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ComputeFunction)");
            base.Visit(node);
            Console.WriteLine("End Visit(ComputeFunction)");
        }

        public override void Visit(ConstraintDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ConstraintDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(ConstraintDefinition)");
        }

        public override void Visit(ContainmentDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ContainmentDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ContainmentDatabaseOption)");
        }

        public override void Visit(ContinueStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ContinueStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(ContinueStatement)");
        }

        public override void Visit(ContractMessage node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ContractMessage)");
            base.Visit(node);
            Console.WriteLine("End Visit(ContractMessage)");
        }

        public override void Visit(ConvertCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ConvertCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(ConvertCall)");
        }

        public override void Visit(CreateAggregateStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateAggregateStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateAggregateStatement)");
        }

        public override void Visit(CreateApplicationRoleStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateApplicationRoleStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateApplicationRoleStatement)");
        }

        public override void Visit(CreateAssemblyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateAssemblyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateAssemblyStatement)");
        }

        public override void Visit(CreateAsymmetricKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateAsymmetricKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateAsymmetricKeyStatement)");
        }

        public override void Visit(CreateAvailabilityGroupStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateAvailabilityGroupStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateAvailabilityGroupStatement)");
        }

        public override void Visit(CreateBrokerPriorityStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateBrokerPriorityStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateBrokerPriorityStatement)");
        }

        public override void Visit(CreateCertificateStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateCertificateStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateCertificateStatement)");
        }

        public override void Visit(CreateColumnStoreIndexStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateColumnStoreIndexStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateColumnStoreIndexStatement)");
        }

        public override void Visit(CreateContractStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateContractStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateContractStatement)");
        }

        public override void Visit(CreateCredentialStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateCredentialStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateCredentialStatement)");
        }

        public override void Visit(CreateCryptographicProviderStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateCryptographicProviderStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateCryptographicProviderStatement)");
        }

        public override void Visit(CreateDatabaseAuditSpecificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateDatabaseAuditSpecificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateDatabaseAuditSpecificationStatement)");
        }

        public override void Visit(CreateDatabaseEncryptionKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateDatabaseEncryptionKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateDatabaseEncryptionKeyStatement)");
        }

        public override void Visit(CreateDatabaseStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateDatabaseStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateDatabaseStatement)");
        }

        public override void Visit(CreateDefaultStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateDefaultStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateDefaultStatement)");
        }

        public override void Visit(CreateEndpointStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateEndpointStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateEndpointStatement)");
        }

        public override void Visit(CreateEventNotificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateEventNotificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateEventNotificationStatement)");
        }

        public override void Visit(CreateEventSessionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateEventSessionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateEventSessionStatement)");
        }

        public override void Visit(CreateFederationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateFederationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateFederationStatement)");
        }

        public override void Visit(CreateFullTextCatalogStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateFullTextCatalogStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateFullTextCatalogStatement)");
        }

        public override void Visit(CreateFullTextIndexStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateFullTextIndexStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateFullTextIndexStatement)");
        }

        public override void Visit(CreateFullTextStopListStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateFullTextStopListStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateFullTextStopListStatement)");
        }

        public override void Visit(CreateFunctionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateFunctionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateFunctionStatement)");
        }

        public override void Visit(CreateIndexStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateIndexStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateIndexStatement)");
        }

        public override void Visit(CreateLoginSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateLoginSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateLoginSource)");
        }

        public override void Visit(CreateLoginStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateLoginStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateLoginStatement)");
        }

        public override void Visit(CreateMasterKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateMasterKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateMasterKeyStatement)");
        }

        public override void Visit(CreateMessageTypeStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateMessageTypeStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateMessageTypeStatement)");
        }

        public override void Visit(CreatePartitionFunctionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreatePartitionFunctionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreatePartitionFunctionStatement)");
        }

        public override void Visit(CreatePartitionSchemeStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreatePartitionSchemeStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreatePartitionSchemeStatement)");
        }

        public override void Visit(CreateProcedureStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateProcedureStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateProcedureStatement)");
        }

        public override void Visit(CreateQueueStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateQueueStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateQueueStatement)");
        }

        public override void Visit(CreateRemoteServiceBindingStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateRemoteServiceBindingStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateRemoteServiceBindingStatement)");
        }

        public override void Visit(CreateResourcePoolStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateResourcePoolStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateResourcePoolStatement)");
        }

        public override void Visit(CreateRoleStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateRoleStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateRoleStatement)");
        }

        public override void Visit(CreateRouteStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateRouteStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateRouteStatement)");
        }

        public override void Visit(CreateRuleStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateRuleStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateRuleStatement)");
        }

        public override void Visit(CreateSchemaStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateSchemaStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateSchemaStatement)");
        }

        public override void Visit(CreateSearchPropertyListStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateSearchPropertyListStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateSearchPropertyListStatement)");
        }
        /*
        public override void Visit(CreateSelectiveXmlIndexStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateSelectiveXmlIndexStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateSelectiveXmlIndexStatement)");
        }
        */
        public override void Visit(CreateSequenceStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateSequenceStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateSequenceStatement)");
        }

        public override void Visit(CreateServerAuditSpecificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateServerAuditSpecificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateServerAuditSpecificationStatement)");
        }

        public override void Visit(CreateServerAuditStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateServerAuditStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateServerAuditStatement)");
        }

        public override void Visit(CreateServerRoleStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateServerRoleStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateServerRoleStatement)");
        }

        public override void Visit(CreateServiceStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateServiceStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateServiceStatement)");
        }

        public override void Visit(CreateSpatialIndexStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateSpatialIndexStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateSpatialIndexStatement)");
        }

        public override void Visit(CreateStatisticsStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateStatisticsStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateStatisticsStatement)");
        }

        public override void Visit(CreateSymmetricKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateSymmetricKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateSymmetricKeyStatement)");
        }

        public override void Visit(CreateSynonymStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateSynonymStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateSynonymStatement)");
        }

        public override void Visit(CreateTableStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateTableStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateTableStatement)");
        }

        public override void Visit(CreateTriggerStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateTriggerStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateTriggerStatement)");
        }

        public override void Visit(CreateTypeStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateTypeStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateTypeStatement)");
        }

        public override void Visit(CreateTypeTableStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateTypeTableStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateTypeTableStatement)");
        }

        public override void Visit(CreateTypeUddtStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateTypeUddtStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateTypeUddtStatement)");
        }

        public override void Visit(CreateTypeUdtStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateTypeUdtStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateTypeUdtStatement)");
        }

        public override void Visit(CreateUserStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateUserStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateUserStatement)");
        }

        public override void Visit(CreateViewStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateViewStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateViewStatement)");
        }

        public override void Visit(CreateWorkloadGroupStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateWorkloadGroupStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateWorkloadGroupStatement)");
        }

        public override void Visit(CreateXmlIndexStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateXmlIndexStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateXmlIndexStatement)");
        }

        public override void Visit(CreateXmlSchemaCollectionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreateXmlSchemaCollectionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreateXmlSchemaCollectionStatement)");
        }

        public override void Visit(CreationDispositionKeyOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CreationDispositionKeyOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(CreationDispositionKeyOption)");
        }

        public override void Visit(CredentialStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CredentialStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CredentialStatement)");
        }

        public override void Visit(CryptoMechanism node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CryptoMechanism)");
            base.Visit(node);
            Console.WriteLine("End Visit(CryptoMechanism)");
        }

        public override void Visit(CubeGroupingSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CubeGroupingSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(CubeGroupingSpecification)");
        }

        public override void Visit(CursorDefaultDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CursorDefaultDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(CursorDefaultDatabaseOption)");
        }

        public override void Visit(CursorDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CursorDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(CursorDefinition)");
        }

        public override void Visit(CursorId node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CursorId)");
            base.Visit(node);
            Console.WriteLine("End Visit(CursorId)");
        }

        public override void Visit(CursorOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CursorOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(CursorOption)");
        }

        public override void Visit(CursorStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(CursorStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(CursorStatement)");
        }

        public override void Visit(DatabaseAuditAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DatabaseAuditAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(DatabaseAuditAction)");
        }

        public override void Visit(DatabaseEncryptionKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DatabaseEncryptionKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DatabaseEncryptionKeyStatement)");
        }

        public override void Visit(DatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(DatabaseOption)");
        }

        public override void Visit(DataCompressionOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DataCompressionOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(DataCompressionOption)");
        }

        public override void Visit(DataModificationSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DataModificationSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(DataModificationSpecification)");
        }

        public override void Visit(DataModificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DataModificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DataModificationStatement)");
        }

        public override void Visit(DataModificationTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DataModificationTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(DataModificationTableReference)");
        }

        public override void Visit(DataTypeReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DataTypeReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(DataTypeReference)");
        }

        public override void Visit(DataTypeSequenceOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DataTypeSequenceOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(DataTypeSequenceOption)");
        }

        public override void Visit(DbccNamedLiteral node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DbccNamedLiteral)");
            base.Visit(node);
            Console.WriteLine("End Visit(DbccNamedLiteral)");
        }

        public override void Visit(DbccOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DbccOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(DbccOption)");
        }

        public override void Visit(DbccStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DbccStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DbccStatement)");
        }

        public override void Visit(DeallocateCursorStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DeallocateCursorStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DeallocateCursorStatement)");
        }

        public override void Visit(DeclareCursorStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DeclareCursorStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DeclareCursorStatement)");
        }

        public override void Visit(DeclareTableVariableBody node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DeclareTableVariableBody)");
            base.Visit(node);
            Console.WriteLine("End Visit(DeclareTableVariableBody)");
        }

        public override void Visit(DeclareTableVariableStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DeclareTableVariableStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DeclareTableVariableStatement)");
        }

        public override void Visit(DeclareVariableElement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DeclareVariableElement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DeclareVariableElement)");
        }

        public override void Visit(DeclareVariableStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DeclareVariableStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DeclareVariableStatement)");
        }

        public override void Visit(DefaultConstraintDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DefaultConstraintDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(DefaultConstraintDefinition)");
        }

        public override void Visit(DefaultLiteral node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DefaultLiteral)");
            base.Visit(node);
            Console.WriteLine("End Visit(DefaultLiteral)");
        }

        public override void Visit(DeleteMergeAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DeleteMergeAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(DeleteMergeAction)");
        }

        public override void Visit(DeleteSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DeleteSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(DeleteSpecification)");
        }

        public override void Visit(DeleteStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DeleteStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DeleteStatement)");
        }

        public override void Visit(DenyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DenyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DenyStatement)");
        }

        public override void Visit(DenyStatement80 node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DenyStatement80)");
            base.Visit(node);
            Console.WriteLine("End Visit(DenyStatement80)");
        }

        public override void Visit(DeviceInfo node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DeviceInfo)");
            base.Visit(node);
            Console.WriteLine("End Visit(DeviceInfo)");
        }

        public override void Visit(DialogOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DialogOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(DialogOption)");
        }

        public override void Visit(DiskStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DiskStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DiskStatement)");
        }

        public override void Visit(DiskStatementOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DiskStatementOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(DiskStatementOption)");
        }

        public override void Visit(DropAggregateStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropAggregateStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropAggregateStatement)");
        }

        public override void Visit(DropAlterFullTextIndexAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropAlterFullTextIndexAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropAlterFullTextIndexAction)");
        }

        public override void Visit(DropApplicationRoleStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropApplicationRoleStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropApplicationRoleStatement)");
        }

        public override void Visit(DropAssemblyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropAssemblyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropAssemblyStatement)");
        }

        public override void Visit(DropAsymmetricKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropAsymmetricKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropAsymmetricKeyStatement)");
        }

        public override void Visit(DropAvailabilityGroupStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropAvailabilityGroupStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropAvailabilityGroupStatement)");
        }

        public override void Visit(DropBrokerPriorityStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropBrokerPriorityStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropBrokerPriorityStatement)");
        }

        public override void Visit(DropCertificateStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropCertificateStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropCertificateStatement)");
        }

        public override void Visit(DropChildObjectsStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropChildObjectsStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropChildObjectsStatement)");
        }

        public override void Visit(DropClusteredConstraintMoveOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropClusteredConstraintMoveOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropClusteredConstraintMoveOption)");
        }

        public override void Visit(DropClusteredConstraintOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropClusteredConstraintOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropClusteredConstraintOption)");
        }

        public override void Visit(DropClusteredConstraintStateOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropClusteredConstraintStateOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropClusteredConstraintStateOption)");
        }

        public override void Visit(DropClusteredConstraintValueOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropClusteredConstraintValueOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropClusteredConstraintValueOption)");
        }

        public override void Visit(DropContractStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropContractStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropContractStatement)");
        }

        public override void Visit(DropCredentialStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropCredentialStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropCredentialStatement)");
        }

        public override void Visit(DropCryptographicProviderStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropCryptographicProviderStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropCryptographicProviderStatement)");
        }

        public override void Visit(DropDatabaseAuditSpecificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropDatabaseAuditSpecificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropDatabaseAuditSpecificationStatement)");
        }

        public override void Visit(DropDatabaseEncryptionKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropDatabaseEncryptionKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropDatabaseEncryptionKeyStatement)");
        }

        public override void Visit(DropDatabaseStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropDatabaseStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropDatabaseStatement)");
        }

        public override void Visit(DropDefaultStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropDefaultStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropDefaultStatement)");
        }

        public override void Visit(DropEndpointStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropEndpointStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropEndpointStatement)");
        }

        public override void Visit(DropEventNotificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropEventNotificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropEventNotificationStatement)");
        }

        public override void Visit(DropEventSessionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropEventSessionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropEventSessionStatement)");
        }

        public override void Visit(DropFederationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropFederationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropFederationStatement)");
        }

        public override void Visit(DropFullTextCatalogStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropFullTextCatalogStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropFullTextCatalogStatement)");
        }

        public override void Visit(DropFullTextIndexStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropFullTextIndexStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropFullTextIndexStatement)");
        }

        public override void Visit(DropFullTextStopListStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropFullTextStopListStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropFullTextStopListStatement)");
        }

        public override void Visit(DropFunctionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropFunctionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropFunctionStatement)");
        }

        public override void Visit(DropIndexClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropIndexClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropIndexClause)");
        }

        public override void Visit(DropIndexClauseBase node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropIndexClauseBase)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropIndexClauseBase)");
        }

        public override void Visit(DropIndexStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropIndexStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropIndexStatement)");
        }

        public override void Visit(DropLoginStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropLoginStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropLoginStatement)");
        }

        public override void Visit(DropMasterKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropMasterKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropMasterKeyStatement)");
        }

        public override void Visit(DropMemberAlterRoleAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropMemberAlterRoleAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropMemberAlterRoleAction)");
        }

        public override void Visit(DropMessageTypeStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropMessageTypeStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropMessageTypeStatement)");
        }

        public override void Visit(DropObjectsStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropObjectsStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropObjectsStatement)");
        }

        public override void Visit(DropPartitionFunctionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropPartitionFunctionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropPartitionFunctionStatement)");
        }

        public override void Visit(DropPartitionSchemeStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropPartitionSchemeStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropPartitionSchemeStatement)");
        }

        public override void Visit(DropProcedureStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropProcedureStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropProcedureStatement)");
        }

        public override void Visit(DropQueueStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropQueueStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropQueueStatement)");
        }

        public override void Visit(DropRemoteServiceBindingStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropRemoteServiceBindingStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropRemoteServiceBindingStatement)");
        }

        public override void Visit(DropResourcePoolStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropResourcePoolStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropResourcePoolStatement)");
        }

        public override void Visit(DropRoleStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropRoleStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropRoleStatement)");
        }

        public override void Visit(DropRouteStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropRouteStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropRouteStatement)");
        }

        public override void Visit(DropRuleStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropRuleStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropRuleStatement)");
        }

        public override void Visit(DropSchemaStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropSchemaStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropSchemaStatement)");
        }

        public override void Visit(DropSearchPropertyListAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropSearchPropertyListAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropSearchPropertyListAction)");
        }

        public override void Visit(DropSearchPropertyListStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropSearchPropertyListStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropSearchPropertyListStatement)");
        }

        public override void Visit(DropSequenceStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropSequenceStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropSequenceStatement)");
        }

        public override void Visit(DropServerAuditSpecificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropServerAuditSpecificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropServerAuditSpecificationStatement)");
        }

        public override void Visit(DropServerAuditStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropServerAuditStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropServerAuditStatement)");
        }

        public override void Visit(DropServerRoleStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropServerRoleStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropServerRoleStatement)");
        }

        public override void Visit(DropServiceStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropServiceStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropServiceStatement)");
        }

        public override void Visit(DropSignatureStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropSignatureStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropSignatureStatement)");
        }

        public override void Visit(DropStatisticsStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropStatisticsStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropStatisticsStatement)");
        }

        public override void Visit(DropSymmetricKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropSymmetricKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropSymmetricKeyStatement)");
        }

        public override void Visit(DropSynonymStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropSynonymStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropSynonymStatement)");
        }

        public override void Visit(DropTableStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropTableStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropTableStatement)");
        }

        public override void Visit(DropTriggerStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropTriggerStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropTriggerStatement)");
        }

        public override void Visit(DropTypeStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropTypeStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropTypeStatement)");
        }

        public override void Visit(DropUnownedObjectStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropUnownedObjectStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropUnownedObjectStatement)");
        }

        public override void Visit(DropUserStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropUserStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropUserStatement)");
        }

        public override void Visit(DropViewStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropViewStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropViewStatement)");
        }

        public override void Visit(DropWorkloadGroupStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropWorkloadGroupStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropWorkloadGroupStatement)");
        }

        public override void Visit(DropXmlSchemaCollectionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(DropXmlSchemaCollectionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(DropXmlSchemaCollectionStatement)");
        }

        public override void Visit(EnabledDisabledPayloadOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EnabledDisabledPayloadOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(EnabledDisabledPayloadOption)");
        }

        public override void Visit(EnableDisableTriggerStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EnableDisableTriggerStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(EnableDisableTriggerStatement)");
        }

        public override void Visit(EncryptionPayloadOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EncryptionPayloadOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(EncryptionPayloadOption)");
        }

        public override void Visit(EncryptionSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EncryptionSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(EncryptionSource)");
        }

        public override void Visit(EndConversationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EndConversationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(EndConversationStatement)");
        }

        public override void Visit(EndpointAffinity node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EndpointAffinity)");
            base.Visit(node);
            Console.WriteLine("End Visit(EndpointAffinity)");
        }

        public override void Visit(EndpointProtocolOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EndpointProtocolOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(EndpointProtocolOption)");
        }

        public override void Visit(EventDeclaration node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EventDeclaration)");
            base.Visit(node);
            Console.WriteLine("End Visit(EventDeclaration)");
        }

        public override void Visit(EventDeclarationCompareFunctionParameter node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EventDeclarationCompareFunctionParameter)");
            base.Visit(node);
            Console.WriteLine("End Visit(EventDeclarationCompareFunctionParameter)");
        }

        public override void Visit(EventDeclarationSetParameter node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EventDeclarationSetParameter)");
            base.Visit(node);
            Console.WriteLine("End Visit(EventDeclarationSetParameter)");
        }

        public override void Visit(EventGroupContainer node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EventGroupContainer)");
            base.Visit(node);
            Console.WriteLine("End Visit(EventGroupContainer)");
        }

        public override void Visit(EventNotificationObjectScope node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EventNotificationObjectScope)");
            base.Visit(node);
            Console.WriteLine("End Visit(EventNotificationObjectScope)");
        }

        public override void Visit(EventRetentionSessionOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EventRetentionSessionOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(EventRetentionSessionOption)");
        }

        public override void Visit(EventSessionObjectName node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EventSessionObjectName)");
            base.Visit(node);
            Console.WriteLine("End Visit(EventSessionObjectName)");
        }

        public override void Visit(EventSessionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EventSessionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(EventSessionStatement)");
        }

        public override void Visit(EventTypeContainer node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EventTypeContainer)");
            base.Visit(node);
            Console.WriteLine("End Visit(EventTypeContainer)");
        }

        public override void Visit(EventTypeGroupContainer node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(EventTypeGroupContainer)");
            base.Visit(node);
            Console.WriteLine("End Visit(EventTypeGroupContainer)");
        }

        public override void Visit(ExecutableEntity node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecutableEntity)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecutableEntity)");
        }

        public override void Visit(ExecutableProcedureReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecutableProcedureReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecutableProcedureReference)");
        }

        public override void Visit(ExecutableStringList node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecutableStringList)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecutableStringList)");
        }

        public override void Visit(ExecuteAsClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecuteAsClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecuteAsClause)");
        }

        public override void Visit(ExecuteAsFunctionOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecuteAsFunctionOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecuteAsFunctionOption)");
        }

        public override void Visit(ExecuteAsProcedureOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecuteAsProcedureOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecuteAsProcedureOption)");
        }

        public override void Visit(ExecuteAsStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecuteAsStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecuteAsStatement)");
        }

        public override void Visit(ExecuteAsTriggerOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecuteAsTriggerOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecuteAsTriggerOption)");
        }

        public override void Visit(ExecuteContext node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecuteContext)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecuteContext)");
        }

        public override void Visit(ExecuteInsertSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecuteInsertSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecuteInsertSource)");
        }

        public override void Visit(ExecuteOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecuteOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecuteOption)");
        }

        public override void Visit(ExecuteParameter node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecuteParameter)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecuteParameter)");
        }

        public override void Visit(ExecuteSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecuteSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecuteSpecification)");
        }

        public override void Visit(ExecuteStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExecuteStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExecuteStatement)");
        }

        public override void Visit(ExistsPredicate node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExistsPredicate)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExistsPredicate)");
        }

        public override void Visit(ExpressionCallTarget node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExpressionCallTarget)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExpressionCallTarget)");
        }

        public override void Visit(ExpressionGroupingSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExpressionGroupingSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExpressionGroupingSpecification)");
        }

        public override void Visit(ExpressionWithSortOrder node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExpressionWithSortOrder)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExpressionWithSortOrder)");
        }

        public override void Visit(ExtractFromExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ExtractFromExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(ExtractFromExpression)");
        }

        public override void Visit(FailoverModeReplicaOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FailoverModeReplicaOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FailoverModeReplicaOption)");
        }

        public override void Visit(FederationScheme node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FederationScheme)");
            base.Visit(node);
            Console.WriteLine("End Visit(FederationScheme)");
        }

        public override void Visit(FetchCursorStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FetchCursorStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(FetchCursorStatement)");
        }

        public override void Visit(FetchType node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FetchType)");
            base.Visit(node);
            Console.WriteLine("End Visit(FetchType)");
        }

        public override void Visit(FileDeclaration node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileDeclaration)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileDeclaration)");
        }

        public override void Visit(FileDeclarationOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileDeclarationOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileDeclarationOption)");
        }

        public override void Visit(FileEncryptionSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileEncryptionSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileEncryptionSource)");
        }

        public override void Visit(FileGroupDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileGroupDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileGroupDefinition)");
        }

        public override void Visit(FileGroupOrPartitionScheme node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileGroupOrPartitionScheme)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileGroupOrPartitionScheme)");
        }

        public override void Visit(FileGrowthFileDeclarationOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileGrowthFileDeclarationOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileGrowthFileDeclarationOption)");
        }

        public override void Visit(FileNameFileDeclarationOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileNameFileDeclarationOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileNameFileDeclarationOption)");
        }

        public override void Visit(FileStreamDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileStreamDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileStreamDatabaseOption)");
        }

        public override void Visit(FileStreamOnDropIndexOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileStreamOnDropIndexOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileStreamOnDropIndexOption)");
        }

        public override void Visit(FileStreamOnTableOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileStreamOnTableOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileStreamOnTableOption)");
        }

        public override void Visit(FileStreamRestoreOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileStreamRestoreOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileStreamRestoreOption)");
        }

        public override void Visit(FileTableCollateFileNameTableOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileTableCollateFileNameTableOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileTableCollateFileNameTableOption)");
        }

        public override void Visit(FileTableConstraintNameTableOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileTableConstraintNameTableOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileTableConstraintNameTableOption)");
        }

        public override void Visit(FileTableDirectoryTableOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FileTableDirectoryTableOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FileTableDirectoryTableOption)");
        }

        public override void Visit(ForceSeekTableHint node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ForceSeekTableHint)");
            base.Visit(node);
            Console.WriteLine("End Visit(ForceSeekTableHint)");
        }

        public override void Visit(ForClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ForClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(ForClause)");
        }

        public override void Visit(ForeignKeyConstraintDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ForeignKeyConstraintDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(ForeignKeyConstraintDefinition)");
        }

        public override void Visit(FromClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FromClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(FromClause)");
        }

        public override void Visit(FullTextCatalogAndFileGroup node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FullTextCatalogAndFileGroup)");
            base.Visit(node);
            Console.WriteLine("End Visit(FullTextCatalogAndFileGroup)");
        }

        public override void Visit(FullTextCatalogOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FullTextCatalogOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FullTextCatalogOption)");
        }

        public override void Visit(FullTextCatalogStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FullTextCatalogStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(FullTextCatalogStatement)");
        }

        public override void Visit(FullTextIndexColumn node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FullTextIndexColumn)");
            base.Visit(node);
            Console.WriteLine("End Visit(FullTextIndexColumn)");
        }

        public override void Visit(FullTextIndexOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FullTextIndexOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FullTextIndexOption)");
        }

        public override void Visit(FullTextPredicate node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FullTextPredicate)");
            base.Visit(node);
            Console.WriteLine("End Visit(FullTextPredicate)");
        }

        public override void Visit(FullTextStopListAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FullTextStopListAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(FullTextStopListAction)");
        }

        public override void Visit(FullTextTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FullTextTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(FullTextTableReference)");
        }

        public override void Visit(FunctionCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FunctionCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(FunctionCall)");
        }

        public override void Visit(FunctionCallSetClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FunctionCallSetClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(FunctionCallSetClause)");
        }

        public override void Visit(FunctionOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FunctionOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(FunctionOption)");
        }

        public override void Visit(FunctionReturnType node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FunctionReturnType)");
            base.Visit(node);
            Console.WriteLine("End Visit(FunctionReturnType)");
        }

        public override void Visit(FunctionStatementBody node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(FunctionStatementBody)");
            base.Visit(node);
            Console.WriteLine("End Visit(FunctionStatementBody)");
        }

        public override void Visit(GeneralSetCommand node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(GeneralSetCommand)");
            base.Visit(node);
            Console.WriteLine("End Visit(GeneralSetCommand)");
        }

        public override void Visit(GetConversationGroupStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(GetConversationGroupStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(GetConversationGroupStatement)");
        }

        public override void Visit(GlobalVariableExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(GlobalVariableExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(GlobalVariableExpression)");
        }

        public override void Visit(GoToStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(GoToStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(GoToStatement)");
        }

        public override void Visit(GrandTotalGroupingSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(GrandTotalGroupingSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(GrandTotalGroupingSpecification)");
        }

        public override void Visit(GrantStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(GrantStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(GrantStatement)");
        }

        public override void Visit(GrantStatement80 node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(GrantStatement80)");
            base.Visit(node);
            Console.WriteLine("End Visit(GrantStatement80)");
        }

        public override void Visit(GridParameter node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(GridParameter)");
            base.Visit(node);
            Console.WriteLine("End Visit(GridParameter)");
        }

        public override void Visit(GridsSpatialIndexOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(GridsSpatialIndexOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(GridsSpatialIndexOption)");
        }

        public override void Visit(GroupByClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(GroupByClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(GroupByClause)");
        }

        public override void Visit(GroupingSetsGroupingSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(GroupingSetsGroupingSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(GroupingSetsGroupingSpecification)");
        }

        public override void Visit(GroupingSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(GroupingSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(GroupingSpecification)");
        }

        public override void Visit(HadrAvailabilityGroupDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(HadrAvailabilityGroupDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(HadrAvailabilityGroupDatabaseOption)");
        }

        public override void Visit(HadrDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(HadrDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(HadrDatabaseOption)");
        }

        public override void Visit(HavingClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(HavingClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(HavingClause)");
        }

        public override void Visit(Identifier node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(Identifier)");
            base.Visit(node);
            Console.WriteLine("End Visit(Identifier)");
        }

        public override void Visit(IdentifierDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IdentifierDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(IdentifierDatabaseOption)");
        }

        public override void Visit(IdentifierLiteral node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IdentifierLiteral)");
            base.Visit(node);
            Console.WriteLine("End Visit(IdentifierLiteral)");
        }

        public override void Visit(IdentifierOrValueExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IdentifierOrValueExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(IdentifierOrValueExpression)");
        }

        public override void Visit(IdentifierPrincipalOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IdentifierPrincipalOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(IdentifierPrincipalOption)");
        }

        public override void Visit(IdentifierSnippet node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IdentifierSnippet)");
            base.Visit(node);
            Console.WriteLine("End Visit(IdentifierSnippet)");
        }

        public override void Visit(IdentityFunctionCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IdentityFunctionCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(IdentityFunctionCall)");
        }

        public override void Visit(IdentityOptions node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IdentityOptions)");
            base.Visit(node);
            Console.WriteLine("End Visit(IdentityOptions)");
        }

        public override void Visit(IdentityValueKeyOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IdentityValueKeyOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(IdentityValueKeyOption)");
        }

        public override void Visit(IfStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IfStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(IfStatement)");
        }

        public override void Visit(IIfCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IIfCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(IIfCall)");
        }

        public override void Visit(IndexExpressionOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IndexExpressionOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(IndexExpressionOption)");
        }

        public override void Visit(IndexOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IndexOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(IndexOption)");
        }

        public override void Visit(IndexStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IndexStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(IndexStatement)");
        }

        public override void Visit(IndexStateOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IndexStateOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(IndexStateOption)");
        }

        public override void Visit(IndexTableHint node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IndexTableHint)");
            base.Visit(node);
            Console.WriteLine("End Visit(IndexTableHint)");
        }

        public override void Visit(InlineDerivedTable node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(InlineDerivedTable)");
            base.Visit(node);
            Console.WriteLine("End Visit(InlineDerivedTable)");
        }

        public override void Visit(InlineResultSetDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(InlineResultSetDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(InlineResultSetDefinition)");
        }

        public override void Visit(InPredicate node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(InPredicate)");
            base.Visit(node);
            Console.WriteLine("End Visit(InPredicate)");
        }

        public override void Visit(InsertBulkColumnDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(InsertBulkColumnDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(InsertBulkColumnDefinition)");
        }

        public override void Visit(InsertBulkStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(InsertBulkStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(InsertBulkStatement)");
        }

        public override void Visit(InsertMergeAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(InsertMergeAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(InsertMergeAction)");
        }

        public override void Visit(InsertSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(InsertSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(InsertSource)");
        }

        public override void Visit(InsertSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(InsertSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(InsertSpecification)");
        }

        public override void Visit(InsertStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(InsertStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(InsertStatement)");
        }

        public override void Visit(IntegerLiteral node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IntegerLiteral)");
            base.Visit(node);
            Console.WriteLine("End Visit(IntegerLiteral)");
        }

        public override void Visit(InternalOpenRowset node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(InternalOpenRowset)");
            base.Visit(node);
            Console.WriteLine("End Visit(InternalOpenRowset)");
        }

        public override void Visit(IPv4 node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(IPv4)");
            base.Visit(node);
            Console.WriteLine("End Visit(IPv4)");
        }

        public override void Visit(JoinParenthesisTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(JoinParenthesisTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(JoinParenthesisTableReference)");
        }

        public override void Visit(JoinTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(JoinTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(JoinTableReference)");
        }

        public override void Visit(KeyOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(KeyOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(KeyOption)");
        }

        public override void Visit(KeySourceKeyOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(KeySourceKeyOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(KeySourceKeyOption)");
        }

        public override void Visit(KillQueryNotificationSubscriptionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(KillQueryNotificationSubscriptionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(KillQueryNotificationSubscriptionStatement)");
        }

        public override void Visit(KillStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(KillStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(KillStatement)");
        }

        public override void Visit(KillStatsJobStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(KillStatsJobStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(KillStatsJobStatement)");
        }

        public override void Visit(LabelStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LabelStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(LabelStatement)");
        }

        public override void Visit(LeftFunctionCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LeftFunctionCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(LeftFunctionCall)");
        }

        public override void Visit(LikePredicate node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LikePredicate)");
            base.Visit(node);
            Console.WriteLine("End Visit(LikePredicate)");
        }

        public override void Visit(LineNoStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LineNoStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(LineNoStatement)");
        }

        public override void Visit(ListenerIPEndpointProtocolOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ListenerIPEndpointProtocolOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ListenerIPEndpointProtocolOption)");
        }

        public override void Visit(Literal node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(Literal)");
            base.Visit(node);
            Console.WriteLine("End Visit(Literal)");
        }

        public override void Visit(LiteralAuditTargetOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LiteralAuditTargetOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(LiteralAuditTargetOption)");
        }

        public override void Visit(LiteralAvailabilityGroupOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LiteralAvailabilityGroupOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(LiteralAvailabilityGroupOption)");
        }

        public override void Visit(LiteralBulkInsertOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LiteralBulkInsertOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(LiteralBulkInsertOption)");
        }

        public override void Visit(LiteralDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LiteralDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(LiteralDatabaseOption)");
        }

        public override void Visit(LiteralEndpointProtocolOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LiteralEndpointProtocolOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(LiteralEndpointProtocolOption)");
        }

        public override void Visit(LiteralOptimizerHint node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LiteralOptimizerHint)");
            base.Visit(node);
            Console.WriteLine("End Visit(LiteralOptimizerHint)");
        }

        public override void Visit(LiteralPayloadOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LiteralPayloadOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(LiteralPayloadOption)");
        }

        public override void Visit(LiteralPrincipalOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LiteralPrincipalOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(LiteralPrincipalOption)");
        }

        public override void Visit(LiteralRange node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LiteralRange)");
            base.Visit(node);
            Console.WriteLine("End Visit(LiteralRange)");
        }

        public override void Visit(LiteralReplicaOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LiteralReplicaOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(LiteralReplicaOption)");
        }

        public override void Visit(LiteralSessionOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LiteralSessionOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(LiteralSessionOption)");
        }

        public override void Visit(LiteralStatisticsOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LiteralStatisticsOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(LiteralStatisticsOption)");
        }

        public override void Visit(LiteralTableHint node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LiteralTableHint)");
            base.Visit(node);
            Console.WriteLine("End Visit(LiteralTableHint)");
        }

        public override void Visit(LockEscalationTableOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LockEscalationTableOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(LockEscalationTableOption)");
        }

        public override void Visit(LoginTypePayloadOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(LoginTypePayloadOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(LoginTypePayloadOption)");
        }

        public override void Visit(MasterKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MasterKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(MasterKeyStatement)");
        }

        public override void Visit(MaxDispatchLatencySessionOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MaxDispatchLatencySessionOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(MaxDispatchLatencySessionOption)");
        }

        public override void Visit(MaxLiteral node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MaxLiteral)");
            base.Visit(node);
            Console.WriteLine("End Visit(MaxLiteral)");
        }

        public override void Visit(MaxRolloverFilesAuditTargetOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MaxRolloverFilesAuditTargetOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(MaxRolloverFilesAuditTargetOption)");
        }

        public override void Visit(MaxSizeAuditTargetOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MaxSizeAuditTargetOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(MaxSizeAuditTargetOption)");
        }

        public override void Visit(MaxSizeDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MaxSizeDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(MaxSizeDatabaseOption)");
        }

        public override void Visit(MaxSizeFileDeclarationOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MaxSizeFileDeclarationOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(MaxSizeFileDeclarationOption)");
        }

        public override void Visit(MemoryPartitionSessionOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MemoryPartitionSessionOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(MemoryPartitionSessionOption)");
        }

        public override void Visit(MergeAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MergeAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(MergeAction)");
        }

        public override void Visit(MergeActionClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MergeActionClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(MergeActionClause)");
        }

        public override void Visit(MergeSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MergeSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(MergeSpecification)");
        }

        public override void Visit(MergeStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MergeStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(MergeStatement)");
        }

        public override void Visit(MessageTypeStatementBase node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MessageTypeStatementBase)");
            base.Visit(node);
            Console.WriteLine("End Visit(MessageTypeStatementBase)");
        }

        public override void Visit(MethodSpecifier node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MethodSpecifier)");
            base.Visit(node);
            Console.WriteLine("End Visit(MethodSpecifier)");
        }

        public override void Visit(MirrorToClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MirrorToClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(MirrorToClause)");
        }

        public override void Visit(MoneyLiteral node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MoneyLiteral)");
            base.Visit(node);
            Console.WriteLine("End Visit(MoneyLiteral)");
        }

        public override void Visit(MoveConversationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MoveConversationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(MoveConversationStatement)");
        }

        public override void Visit(MoveRestoreOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MoveRestoreOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(MoveRestoreOption)");
        }

        public override void Visit(MoveToDropIndexOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MoveToDropIndexOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(MoveToDropIndexOption)");
        }

        public override void Visit(MultiPartIdentifier node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MultiPartIdentifier)");
            base.Visit(node);
            Console.WriteLine("End Visit(MultiPartIdentifier)");
        }

        public override void Visit(MultiPartIdentifierCallTarget node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(MultiPartIdentifierCallTarget)");
            base.Visit(node);
            Console.WriteLine("End Visit(MultiPartIdentifierCallTarget)");
        }

        public override void Visit(NamedTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(NamedTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(NamedTableReference)");
        }

        public override void Visit(NameFileDeclarationOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(NameFileDeclarationOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(NameFileDeclarationOption)");
        }

        public override void Visit(NextValueForExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(NextValueForExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(NextValueForExpression)");
        }

        public override void Visit(NullableConstraintDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(NullableConstraintDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(NullableConstraintDefinition)");
        }

        public override void Visit(NullIfExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(NullIfExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(NullIfExpression)");
        }

        public override void Visit(NullLiteral node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(NullLiteral)");
            base.Visit(node);
            Console.WriteLine("End Visit(NullLiteral)");
        }

        public override void Visit(NumericLiteral node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(NumericLiteral)");
            base.Visit(node);
            Console.WriteLine("End Visit(NumericLiteral)");
        }

        public override void Visit(OdbcConvertSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OdbcConvertSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(OdbcConvertSpecification)");
        }

        public override void Visit(OdbcFunctionCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OdbcFunctionCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(OdbcFunctionCall)");
        }

        public override void Visit(OdbcLiteral node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OdbcLiteral)");
            base.Visit(node);
            Console.WriteLine("End Visit(OdbcLiteral)");
        }

        public override void Visit(OdbcQualifiedJoinTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OdbcQualifiedJoinTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(OdbcQualifiedJoinTableReference)");
        }

        public override void Visit(OffsetClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OffsetClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(OffsetClause)");
        }

        public override void Visit(OnFailureAuditOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OnFailureAuditOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(OnFailureAuditOption)");
        }

        public override void Visit(OnOffAssemblyOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OnOffAssemblyOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(OnOffAssemblyOption)");
        }

        public override void Visit(OnOffAuditTargetOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OnOffAuditTargetOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(OnOffAuditTargetOption)");
        }

        public override void Visit(OnOffDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OnOffDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(OnOffDatabaseOption)");
        }

        public override void Visit(OnOffDialogOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OnOffDialogOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(OnOffDialogOption)");
        }

        public override void Visit(OnOffFullTextCatalogOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OnOffFullTextCatalogOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(OnOffFullTextCatalogOption)");
        }

        public override void Visit(OnOffPrincipalOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OnOffPrincipalOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(OnOffPrincipalOption)");
        }

        public override void Visit(OnOffRemoteServiceBindingOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OnOffRemoteServiceBindingOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(OnOffRemoteServiceBindingOption)");
        }

        public override void Visit(OnOffSessionOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OnOffSessionOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(OnOffSessionOption)");
        }

        public override void Visit(OpenCursorStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OpenCursorStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(OpenCursorStatement)");
        }

        public override void Visit(OpenMasterKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OpenMasterKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(OpenMasterKeyStatement)");
        }

        public override void Visit(OpenQueryTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OpenQueryTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(OpenQueryTableReference)");
        }

        public override void Visit(OpenRowsetTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OpenRowsetTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(OpenRowsetTableReference)");
        }

        public override void Visit(OpenSymmetricKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OpenSymmetricKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(OpenSymmetricKeyStatement)");
        }

        public override void Visit(OpenXmlTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OpenXmlTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(OpenXmlTableReference)");
        }

        public override void Visit(OptimizeForOptimizerHint node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OptimizeForOptimizerHint)");
            base.Visit(node);
            Console.WriteLine("End Visit(OptimizeForOptimizerHint)");
        }

        public override void Visit(OptimizerHint node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OptimizerHint)");
            base.Visit(node);
            Console.WriteLine("End Visit(OptimizerHint)");
        }

        public override void Visit(OrderBulkInsertOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OrderBulkInsertOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(OrderBulkInsertOption)");
        }

        public override void Visit(OrderByClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OrderByClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(OrderByClause)");
        }

        public override void Visit(OutputClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OutputClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(OutputClause)");
        }

        public override void Visit(OutputIntoClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OutputIntoClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(OutputIntoClause)");
        }

        public override void Visit(OverClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(OverClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(OverClause)");
        }

        public override void Visit(PageVerifyDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PageVerifyDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(PageVerifyDatabaseOption)");
        }

        public override void Visit(ParameterizationDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ParameterizationDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ParameterizationDatabaseOption)");
        }

        public override void Visit(ParameterizedDataTypeReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ParameterizedDataTypeReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(ParameterizedDataTypeReference)");
        }

        public override void Visit(ParameterlessCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ParameterlessCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(ParameterlessCall)");
        }

        public override void Visit(ParenthesisExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ParenthesisExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(ParenthesisExpression)");
        }

        public override void Visit(ParseCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ParseCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(ParseCall)");
        }

        public override void Visit(PartitionFunctionCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PartitionFunctionCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(PartitionFunctionCall)");
        }

        public override void Visit(PartitionParameterType node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PartitionParameterType)");
            base.Visit(node);
            Console.WriteLine("End Visit(PartitionParameterType)");
        }

        public override void Visit(PartitionSpecifier node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PartitionSpecifier)");
            base.Visit(node);
            Console.WriteLine("End Visit(PartitionSpecifier)");
        }

        public override void Visit(PartnerDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PartnerDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(PartnerDatabaseOption)");
        }

        public override void Visit(PasswordAlterPrincipalOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PasswordAlterPrincipalOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(PasswordAlterPrincipalOption)");
        }

        public override void Visit(PasswordCreateLoginSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PasswordCreateLoginSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(PasswordCreateLoginSource)");
        }

        public override void Visit(PayloadOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PayloadOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(PayloadOption)");
        }

        public override void Visit(Permission node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(Permission)");
            base.Visit(node);
            Console.WriteLine("End Visit(Permission)");
        }

        public override void Visit(PermissionSetAssemblyOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PermissionSetAssemblyOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(PermissionSetAssemblyOption)");
        }

        public override void Visit(PivotedTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PivotedTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(PivotedTableReference)");
        }

        public override void Visit(PortsEndpointProtocolOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PortsEndpointProtocolOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(PortsEndpointProtocolOption)");
        }

        public override void Visit(PredicateSetStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PredicateSetStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(PredicateSetStatement)");
        }

        public override void Visit(PrimaryExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PrimaryExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(PrimaryExpression)");
        }

        public override void Visit(PrimaryRoleReplicaOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PrimaryRoleReplicaOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(PrimaryRoleReplicaOption)");
        }

        public override void Visit(PrincipalOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PrincipalOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(PrincipalOption)");
        }

        public override void Visit(PrintStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PrintStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(PrintStatement)");
        }

        public override void Visit(Privilege80 node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(Privilege80)");
            base.Visit(node);
            Console.WriteLine("End Visit(Privilege80)");
        }

        public override void Visit(PrivilegeSecurityElement80 node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(PrivilegeSecurityElement80)");
            base.Visit(node);
            Console.WriteLine("End Visit(PrivilegeSecurityElement80)");
        }

        public override void Visit(ProcedureOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ProcedureOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ProcedureOption)");
        }

        public override void Visit(ProcedureParameter node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ProcedureParameter)");
            base.Visit(node);
            Console.WriteLine("End Visit(ProcedureParameter)");
        }

        public override void Visit(ProcedureReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ProcedureReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(ProcedureReference)");
        }

        public override void Visit(ProcedureReferenceName node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ProcedureReferenceName)");
            base.Visit(node);
            Console.WriteLine("End Visit(ProcedureReferenceName)");
        }

        public override void Visit(ProcedureStatementBody node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ProcedureStatementBody)");
            base.Visit(node);
            Console.WriteLine("End Visit(ProcedureStatementBody)");
        }

        public override void Visit(ProcedureStatementBodyBase node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ProcedureStatementBodyBase)");
            base.Visit(node);
            Console.WriteLine("End Visit(ProcedureStatementBodyBase)");
        }

        public override void Visit(ProcessAffinityRange node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ProcessAffinityRange)");
            base.Visit(node);
            Console.WriteLine("End Visit(ProcessAffinityRange)");
        }

        public override void Visit(ProviderEncryptionSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ProviderEncryptionSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(ProviderEncryptionSource)");
        }

        public override void Visit(ProviderKeyNameKeyOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ProviderKeyNameKeyOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ProviderKeyNameKeyOption)");
        }

        public override void Visit(QualifiedJoin node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(QualifiedJoin)");
            base.Visit(node);
            Console.WriteLine("End Visit(QualifiedJoin)");
        }

        public override void Visit(QueryDerivedTable node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(QueryDerivedTable)");
            base.Visit(node);
            Console.WriteLine("End Visit(QueryDerivedTable)");
        }

        public override void Visit(QueryExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(QueryExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(QueryExpression)");
        }

        public override void Visit(QueryParenthesisExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(QueryParenthesisExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(QueryParenthesisExpression)");
        }

        public override void Visit(QuerySpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(QuerySpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(QuerySpecification)");
        }

        public override void Visit(QueueDelayAuditOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(QueueDelayAuditOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(QueueDelayAuditOption)");
        }

        public override void Visit(QueueExecuteAsOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(QueueExecuteAsOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(QueueExecuteAsOption)");
        }

        public override void Visit(QueueOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(QueueOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(QueueOption)");
        }

        public override void Visit(QueueProcedureOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(QueueProcedureOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(QueueProcedureOption)");
        }

        public override void Visit(QueueStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(QueueStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(QueueStatement)");
        }

        public override void Visit(QueueStateOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(QueueStateOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(QueueStateOption)");
        }

        public override void Visit(QueueValueOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(QueueValueOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(QueueValueOption)");
        }

        public override void Visit(RaiseErrorLegacyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RaiseErrorLegacyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(RaiseErrorLegacyStatement)");
        }

        public override void Visit(RaiseErrorStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RaiseErrorStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(RaiseErrorStatement)");
        }

        public override void Visit(ReadOnlyForClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ReadOnlyForClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(ReadOnlyForClause)");
        }

        public override void Visit(ReadTextStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ReadTextStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(ReadTextStatement)");
        }

        public override void Visit(RealLiteral node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RealLiteral)");
            base.Visit(node);
            Console.WriteLine("End Visit(RealLiteral)");
        }

        public override void Visit(ReceiveStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ReceiveStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(ReceiveStatement)");
        }

        public override void Visit(ReconfigureStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ReconfigureStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(ReconfigureStatement)");
        }

        public override void Visit(RecoveryDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RecoveryDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(RecoveryDatabaseOption)");
        }

        public override void Visit(RemoteServiceBindingOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RemoteServiceBindingOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(RemoteServiceBindingOption)");
        }

        public override void Visit(RemoteServiceBindingStatementBase node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RemoteServiceBindingStatementBase)");
            base.Visit(node);
            Console.WriteLine("End Visit(RemoteServiceBindingStatementBase)");
        }

        public override void Visit(RenameAlterRoleAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RenameAlterRoleAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(RenameAlterRoleAction)");
        }

        public override void Visit(ResourcePoolAffinitySpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ResourcePoolAffinitySpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(ResourcePoolAffinitySpecification)");
        }

        public override void Visit(ResourcePoolParameter node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ResourcePoolParameter)");
            base.Visit(node);
            Console.WriteLine("End Visit(ResourcePoolParameter)");
        }

        public override void Visit(ResourcePoolStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ResourcePoolStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(ResourcePoolStatement)");
        }

        public override void Visit(RestoreMasterKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RestoreMasterKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(RestoreMasterKeyStatement)");
        }

        public override void Visit(RestoreOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RestoreOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(RestoreOption)");
        }

        public override void Visit(RestoreServiceMasterKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RestoreServiceMasterKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(RestoreServiceMasterKeyStatement)");
        }

        public override void Visit(RestoreStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RestoreStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(RestoreStatement)");
        }

        public override void Visit(ResultColumnDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ResultColumnDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(ResultColumnDefinition)");
        }

        public override void Visit(ResultSetDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ResultSetDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(ResultSetDefinition)");
        }

        public override void Visit(ResultSetsExecuteOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ResultSetsExecuteOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ResultSetsExecuteOption)");
        }

        public override void Visit(ReturnStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ReturnStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(ReturnStatement)");
        }

        public override void Visit(RevertStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RevertStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(RevertStatement)");
        }

        public override void Visit(RevokeStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RevokeStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(RevokeStatement)");
        }

        public override void Visit(RevokeStatement80 node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RevokeStatement80)");
            base.Visit(node);
            Console.WriteLine("End Visit(RevokeStatement80)");
        }

        public override void Visit(RightFunctionCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RightFunctionCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(RightFunctionCall)");
        }

        public override void Visit(RolePayloadOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RolePayloadOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(RolePayloadOption)");
        }

        public override void Visit(RoleStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RoleStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(RoleStatement)");
        }

        public override void Visit(RollbackTransactionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RollbackTransactionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(RollbackTransactionStatement)");
        }

        public override void Visit(RollupGroupingSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RollupGroupingSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(RollupGroupingSpecification)");
        }

        public override void Visit(RouteOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RouteOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(RouteOption)");
        }

        public override void Visit(RouteStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RouteStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(RouteStatement)");
        }

        public override void Visit(RowValue node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(RowValue)");
            base.Visit(node);
            Console.WriteLine("End Visit(RowValue)");
        }

        public override void Visit(SaveTransactionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SaveTransactionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SaveTransactionStatement)");
        }

        public override void Visit(ScalarExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ScalarExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(ScalarExpression)");
        }

        public override void Visit(ScalarExpressionDialogOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ScalarExpressionDialogOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ScalarExpressionDialogOption)");
        }

        public override void Visit(ScalarExpressionRestoreOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ScalarExpressionRestoreOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ScalarExpressionRestoreOption)");
        }

        public override void Visit(ScalarExpressionSequenceOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ScalarExpressionSequenceOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ScalarExpressionSequenceOption)");
        }

        public override void Visit(ScalarExpressionSnippet node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ScalarExpressionSnippet)");
            base.Visit(node);
            Console.WriteLine("End Visit(ScalarExpressionSnippet)");
        }

        public override void Visit(ScalarFunctionReturnType node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ScalarFunctionReturnType)");
            base.Visit(node);
            Console.WriteLine("End Visit(ScalarFunctionReturnType)");
        }

        public override void Visit(ScalarSubquery node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ScalarSubquery)");
            base.Visit(node);
            Console.WriteLine("End Visit(ScalarSubquery)");
        }

        public override void Visit(SchemaDeclarationItem node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SchemaDeclarationItem)");
            base.Visit(node);
            Console.WriteLine("End Visit(SchemaDeclarationItem)");
        }

        public override void Visit(SchemaObjectFunctionTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SchemaObjectFunctionTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(SchemaObjectFunctionTableReference)");
        }

        public override void Visit(SchemaObjectName node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SchemaObjectName)");
            base.Visit(node);
            Console.WriteLine("End Visit(SchemaObjectName)");
        }

        public override void Visit(SchemaObjectNameOrValueExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SchemaObjectNameOrValueExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(SchemaObjectNameOrValueExpression)");
        }

        public override void Visit(SchemaObjectNameSnippet node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SchemaObjectNameSnippet)");
            base.Visit(node);
            Console.WriteLine("End Visit(SchemaObjectNameSnippet)");
        }

        public override void Visit(SchemaObjectResultSetDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SchemaObjectResultSetDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(SchemaObjectResultSetDefinition)");
        }

        public override void Visit(SchemaPayloadOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SchemaPayloadOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(SchemaPayloadOption)");
        }

        public override void Visit(SearchedCaseExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SearchedCaseExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(SearchedCaseExpression)");
        }

        public override void Visit(SearchedWhenClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SearchedWhenClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(SearchedWhenClause)");
        }

        public override void Visit(SearchPropertyListAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SearchPropertyListAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(SearchPropertyListAction)");
        }

        public override void Visit(SearchPropertyListFullTextIndexOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SearchPropertyListFullTextIndexOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(SearchPropertyListFullTextIndexOption)");
        }

        public override void Visit(SecondaryRoleReplicaOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SecondaryRoleReplicaOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(SecondaryRoleReplicaOption)");
        }

        public override void Visit(SecurityElement80 node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SecurityElement80)");
            base.Visit(node);
            Console.WriteLine("End Visit(SecurityElement80)");
        }

        public override void Visit(SecurityPrincipal node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SecurityPrincipal)");
            base.Visit(node);
            Console.WriteLine("End Visit(SecurityPrincipal)");
        }

        public override void Visit(SecurityStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SecurityStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SecurityStatement)");
        }

        public override void Visit(SecurityStatementBody80 node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SecurityStatementBody80)");
            base.Visit(node);
            Console.WriteLine("End Visit(SecurityStatementBody80)");
        }

        public override void Visit(SecurityTargetObject node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SecurityTargetObject)");
            base.Visit(node);
            Console.WriteLine("End Visit(SecurityTargetObject)");
        }

        public override void Visit(SecurityTargetObjectName node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SecurityTargetObjectName)");
            base.Visit(node);
            Console.WriteLine("End Visit(SecurityTargetObjectName)");
        }

        public override void Visit(SecurityUserClause80 node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SecurityUserClause80)");
            base.Visit(node);
            Console.WriteLine("End Visit(SecurityUserClause80)");
        }

        public override void Visit(SelectElement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SelectElement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SelectElement)");
        }

        public override void Visit(SelectFunctionReturnType node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SelectFunctionReturnType)");
            base.Visit(node);
            Console.WriteLine("End Visit(SelectFunctionReturnType)");
        }

        public override void Visit(SelectInsertSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SelectInsertSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(SelectInsertSource)");
        }
        /*
        public override void Visit(SelectiveXmlIndexPromotedPath node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SelectiveXmlIndexPromotedPath)");
            base.Visit(node);
            Console.WriteLine("End Visit(SelectiveXmlIndexPromotedPath)");
        }
        */
        public override void Visit(SelectScalarExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SelectScalarExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(SelectScalarExpression)");
        }

        public override void Visit(SelectSetVariable node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SelectSetVariable)");
            base.Visit(node);
            Console.WriteLine("End Visit(SelectSetVariable)");
        }

        public override void Visit(SelectStarExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SelectStarExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(SelectStarExpression)");
        }

        public override void Visit(SelectStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SelectStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SelectStatement)");
        }

        public override void Visit(SelectStatementSnippet node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SelectStatementSnippet)");
            base.Visit(node);
            Console.WriteLine("End Visit(SelectStatementSnippet)");
        }

        public override void Visit(SemanticTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SemanticTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(SemanticTableReference)");
        }

        public override void Visit(SendStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SendStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SendStatement)");
        }

        public override void Visit(SequenceOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SequenceOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(SequenceOption)");
        }

        public override void Visit(SequenceStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SequenceStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SequenceStatement)");
        }

        public override void Visit(ServerAuditStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ServerAuditStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(ServerAuditStatement)");
        }

        public override void Visit(ServiceContract node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ServiceContract)");
            base.Visit(node);
            Console.WriteLine("End Visit(ServiceContract)");
        }

        public override void Visit(SessionOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SessionOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(SessionOption)");
        }

        public override void Visit(SessionTimeoutPayloadOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SessionTimeoutPayloadOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(SessionTimeoutPayloadOption)");
        }

        public override void Visit(SetClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetClause)");
        }

        public override void Visit(SetCommand node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetCommand)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetCommand)");
        }

        public override void Visit(SetCommandStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetCommandStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetCommandStatement)");
        }

        public override void Visit(SetErrorLevelStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetErrorLevelStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetErrorLevelStatement)");
        }

        public override void Visit(SetFipsFlaggerCommand node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetFipsFlaggerCommand)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetFipsFlaggerCommand)");
        }

        public override void Visit(SetIdentityInsertStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetIdentityInsertStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetIdentityInsertStatement)");
        }

        public override void Visit(SetOffsetsStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetOffsetsStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetOffsetsStatement)");
        }

        public override void Visit(SetOnOffStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetOnOffStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetOnOffStatement)");
        }

        public override void Visit(SetRowCountStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetRowCountStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetRowCountStatement)");
        }

        public override void Visit(SetSearchPropertyListAlterFullTextIndexAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetSearchPropertyListAlterFullTextIndexAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetSearchPropertyListAlterFullTextIndexAction)");
        }

        public override void Visit(SetStatisticsStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetStatisticsStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetStatisticsStatement)");
        }

        public override void Visit(SetStopListAlterFullTextIndexAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetStopListAlterFullTextIndexAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetStopListAlterFullTextIndexAction)");
        }

        public override void Visit(SetTextSizeStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetTextSizeStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetTextSizeStatement)");
        }

        public override void Visit(SetTransactionIsolationLevelStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetTransactionIsolationLevelStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetTransactionIsolationLevelStatement)");
        }

        public override void Visit(SetUserStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetUserStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetUserStatement)");
        }

        public override void Visit(SetVariableStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SetVariableStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SetVariableStatement)");
        }

        public override void Visit(ShutdownStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ShutdownStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(ShutdownStatement)");
        }

        public override void Visit(SignatureStatementBase node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SignatureStatementBase)");
            base.Visit(node);
            Console.WriteLine("End Visit(SignatureStatementBase)");
        }

        public override void Visit(SimpleAlterFullTextIndexAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SimpleAlterFullTextIndexAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(SimpleAlterFullTextIndexAction)");
        }

        public override void Visit(SimpleCaseExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SimpleCaseExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(SimpleCaseExpression)");
        }

        public override void Visit(SimpleWhenClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SimpleWhenClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(SimpleWhenClause)");
        }

        public override void Visit(SizeFileDeclarationOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SizeFileDeclarationOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(SizeFileDeclarationOption)");
        }

        public override void Visit(SoapMethod node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SoapMethod)");
            base.Visit(node);
            Console.WriteLine("End Visit(SoapMethod)");
        }

        public override void Visit(SourceDeclaration node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SourceDeclaration)");
            base.Visit(node);
            Console.WriteLine("End Visit(SourceDeclaration)");
        }

        public override void Visit(SpatialIndexOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SpatialIndexOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(SpatialIndexOption)");
        }

        public override void Visit(SpatialIndexRegularOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SpatialIndexRegularOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(SpatialIndexRegularOption)");
        }

        public override void Visit(SqlCommandIdentifier node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SqlCommandIdentifier)");
            base.Visit(node);
            Console.WriteLine("End Visit(SqlCommandIdentifier)");
        }

        public override void Visit(SqlDataTypeReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SqlDataTypeReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(SqlDataTypeReference)");
        }

        public override void Visit(StateAuditOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(StateAuditOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(StateAuditOption)");
        }

        public override void Visit(StatementList node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(StatementList)");
            base.Visit(node);
            Console.WriteLine("End Visit(StatementList)");
        }

        public override void Visit(StatementListSnippet node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(StatementListSnippet)");
            base.Visit(node);
            Console.WriteLine("End Visit(StatementListSnippet)");
        }

        public override void Visit(StatementWithCtesAndXmlNamespaces node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(StatementWithCtesAndXmlNamespaces)");
            base.Visit(node);
            Console.WriteLine("End Visit(StatementWithCtesAndXmlNamespaces)");
        }

        public override void Visit(StatisticsOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(StatisticsOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(StatisticsOption)");
        }

        public override void Visit(StopListFullTextIndexOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(StopListFullTextIndexOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(StopListFullTextIndexOption)");
        }

        public override void Visit(StopRestoreOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(StopRestoreOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(StopRestoreOption)");
        }

        public override void Visit(StringLiteral node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(StringLiteral)");
            base.Visit(node);
            Console.WriteLine("End Visit(StringLiteral)");
        }

        public override void Visit(SubqueryComparisonPredicate node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SubqueryComparisonPredicate)");
            base.Visit(node);
            Console.WriteLine("End Visit(SubqueryComparisonPredicate)");
        }

        public override void Visit(SymmetricKeyStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(SymmetricKeyStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(SymmetricKeyStatement)");
        }

        public override void Visit(TableDataCompressionOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TableDataCompressionOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(TableDataCompressionOption)");
        }

        public override void Visit(TableDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TableDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(TableDefinition)");
        }

        public override void Visit(TableHint node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TableHint)");
            base.Visit(node);
            Console.WriteLine("End Visit(TableHint)");
        }

        public override void Visit(TableHintsOptimizerHint node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TableHintsOptimizerHint)");
            base.Visit(node);
            Console.WriteLine("End Visit(TableHintsOptimizerHint)");
        }

        public override void Visit(TableOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TableOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(TableOption)");
        }

        public override void Visit(TableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(TableReference)");
        }

        public override void Visit(TableReferenceWithAlias node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TableReferenceWithAlias)");
            base.Visit(node);
            Console.WriteLine("End Visit(TableReferenceWithAlias)");
        }

        public override void Visit(TableReferenceWithAliasAndColumns node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TableReferenceWithAliasAndColumns)");
            base.Visit(node);
            Console.WriteLine("End Visit(TableReferenceWithAliasAndColumns)");
        }

        public override void Visit(TableSampleClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TableSampleClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(TableSampleClause)");
        }

        public override void Visit(TableValuedFunctionReturnType node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TableValuedFunctionReturnType)");
            base.Visit(node);
            Console.WriteLine("End Visit(TableValuedFunctionReturnType)");
        }

        public override void Visit(TargetDeclaration node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TargetDeclaration)");
            base.Visit(node);
            Console.WriteLine("End Visit(TargetDeclaration)");
        }

        public override void Visit(TargetRecoveryTimeDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TargetRecoveryTimeDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(TargetRecoveryTimeDatabaseOption)");
        }

        public override void Visit(TextModificationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TextModificationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(TextModificationStatement)");
        }

        public override void Visit(ThrowStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ThrowStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(ThrowStatement)");
        }

        public override void Visit(TopRowFilter node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TopRowFilter)");
            base.Visit(node);
            Console.WriteLine("End Visit(TopRowFilter)");
        }

        public override void Visit(TransactionStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TransactionStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(TransactionStatement)");
        }

        public override void Visit(TriggerAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TriggerAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(TriggerAction)");
        }

        public override void Visit(TriggerObject node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TriggerObject)");
            base.Visit(node);
            Console.WriteLine("End Visit(TriggerObject)");
        }

        public override void Visit(TriggerOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TriggerOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(TriggerOption)");
        }

        public override void Visit(TriggerStatementBody node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TriggerStatementBody)");
            base.Visit(node);
            Console.WriteLine("End Visit(TriggerStatementBody)");
        }

        public override void Visit(TruncateTableStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TruncateTableStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(TruncateTableStatement)");
        }

        public override void Visit(TryCastCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TryCastCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(TryCastCall)");
        }

        public override void Visit(TryCatchStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TryCatchStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(TryCatchStatement)");
        }

        public override void Visit(TryConvertCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TryConvertCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(TryConvertCall)");
        }

        public override void Visit(TryParseCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TryParseCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(TryParseCall)");
        }

        public override void Visit(TSEqualCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TSEqualCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(TSEqualCall)");
        }

        public override void Visit(TSqlBatch node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TSqlBatch)");
            base.Visit(node);
            Console.WriteLine("End Visit(TSqlBatch)");
        }

        public override void Visit(TSqlFragment node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TSqlFragment)");
            base.Visit(node);
            Console.WriteLine("End Visit(TSqlFragment)");
        }

        public override void Visit(TSqlFragmentSnippet node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TSqlFragmentSnippet)");
            base.Visit(node);
            Console.WriteLine("End Visit(TSqlFragmentSnippet)");
        }

        public override void Visit(TSqlScript node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TSqlScript)");
            base.Visit(node);
            Console.WriteLine("End Visit(TSqlScript)");
        }

        public override void Visit(TSqlStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TSqlStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(TSqlStatement)");
        }

        public override void Visit(TSqlStatementSnippet node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(TSqlStatementSnippet)");
            base.Visit(node);
            Console.WriteLine("End Visit(TSqlStatementSnippet)");
        }

        public override void Visit(UnaryExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UnaryExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(UnaryExpression)");
        }

        public override void Visit(UniqueConstraintDefinition node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UniqueConstraintDefinition)");
            base.Visit(node);
            Console.WriteLine("End Visit(UniqueConstraintDefinition)");
        }

        public override void Visit(UnpivotedTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UnpivotedTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(UnpivotedTableReference)");
        }

        public override void Visit(UnqualifiedJoin node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UnqualifiedJoin)");
            base.Visit(node);
            Console.WriteLine("End Visit(UnqualifiedJoin)");
        }

        public override void Visit(UpdateCall node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UpdateCall)");
            base.Visit(node);
            Console.WriteLine("End Visit(UpdateCall)");
        }

        public override void Visit(UpdateDeleteSpecificationBase node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UpdateDeleteSpecificationBase)");
            base.Visit(node);
            Console.WriteLine("End Visit(UpdateDeleteSpecificationBase)");
        }

        public override void Visit(UpdateForClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UpdateForClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(UpdateForClause)");
        }

        public override void Visit(UpdateMergeAction node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UpdateMergeAction)");
            base.Visit(node);
            Console.WriteLine("End Visit(UpdateMergeAction)");
        }

        public override void Visit(UpdateSpecification node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UpdateSpecification)");
            base.Visit(node);
            Console.WriteLine("End Visit(UpdateSpecification)");
        }

        public override void Visit(UpdateStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UpdateStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(UpdateStatement)");
        }

        public override void Visit(UpdateStatisticsStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UpdateStatisticsStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(UpdateStatisticsStatement)");
        }

        public override void Visit(UpdateTextStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UpdateTextStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(UpdateTextStatement)");
        }

        public override void Visit(UseFederationStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UseFederationStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(UseFederationStatement)");
        }

        public override void Visit(UserDataTypeReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UserDataTypeReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(UserDataTypeReference)");
        }

        public override void Visit(UserDefinedTypeCallTarget node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UserDefinedTypeCallTarget)");
            base.Visit(node);
            Console.WriteLine("End Visit(UserDefinedTypeCallTarget)");
        }

        public override void Visit(UserDefinedTypePropertyAccess node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UserDefinedTypePropertyAccess)");
            base.Visit(node);
            Console.WriteLine("End Visit(UserDefinedTypePropertyAccess)");
        }

        public override void Visit(UserLoginOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UserLoginOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(UserLoginOption)");
        }

        public override void Visit(UserRemoteServiceBindingOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UserRemoteServiceBindingOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(UserRemoteServiceBindingOption)");
        }

        public override void Visit(UserStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UserStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(UserStatement)");
        }

        public override void Visit(UseStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(UseStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(UseStatement)");
        }

        public override void Visit(ValueExpression node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ValueExpression)");
            base.Visit(node);
            Console.WriteLine("End Visit(ValueExpression)");
        }

        public override void Visit(ValuesInsertSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ValuesInsertSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(ValuesInsertSource)");
        }

        public override void Visit(VariableMethodCallTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(VariableMethodCallTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(VariableMethodCallTableReference)");
        }

        public override void Visit(VariableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(VariableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(VariableReference)");
        }

        public override void Visit(VariableTableReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(VariableTableReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(VariableTableReference)");
        }

        public override void Visit(VariableValuePair node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(VariableValuePair)");
            base.Visit(node);
            Console.WriteLine("End Visit(VariableValuePair)");
        }

        public override void Visit(ViewOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ViewOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(ViewOption)");
        }

        public override void Visit(ViewStatementBody node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(ViewStatementBody)");
            base.Visit(node);
            Console.WriteLine("End Visit(ViewStatementBody)");
        }

        public override void Visit(WaitForStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WaitForStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(WaitForStatement)");
        }

        public override void Visit(WaitForSupportedStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WaitForSupportedStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(WaitForSupportedStatement)");
        }

        public override void Visit(WhenClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WhenClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(WhenClause)");
        }

        public override void Visit(WhereClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WhereClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(WhereClause)");
        }

        public override void Visit(WhileStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WhileStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(WhileStatement)");
        }

        public override void Visit(WindowDelimiter node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WindowDelimiter)");
            base.Visit(node);
            Console.WriteLine("End Visit(WindowDelimiter)");
        }

        public override void Visit(WindowFrameClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WindowFrameClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(WindowFrameClause)");
        }

        public override void Visit(WindowsCreateLoginSource node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WindowsCreateLoginSource)");
            base.Visit(node);
            Console.WriteLine("End Visit(WindowsCreateLoginSource)");
        }

        public override void Visit(WithCtesAndXmlNamespaces node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WithCtesAndXmlNamespaces)");
            base.Visit(node);
            Console.WriteLine("End Visit(WithCtesAndXmlNamespaces)");
        }

        public override void Visit(WithinGroupClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WithinGroupClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(WithinGroupClause)");
        }

        public override void Visit(WitnessDatabaseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WitnessDatabaseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(WitnessDatabaseOption)");
        }

        public override void Visit(WorkloadGroupImportanceParameter node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WorkloadGroupImportanceParameter)");
            base.Visit(node);
            Console.WriteLine("End Visit(WorkloadGroupImportanceParameter)");
        }

        public override void Visit(WorkloadGroupParameter node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WorkloadGroupParameter)");
            base.Visit(node);
            Console.WriteLine("End Visit(WorkloadGroupParameter)");
        }

        public override void Visit(WorkloadGroupResourceParameter node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WorkloadGroupResourceParameter)");
            base.Visit(node);
            Console.WriteLine("End Visit(WorkloadGroupResourceParameter)");
        }

        public override void Visit(WorkloadGroupStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WorkloadGroupStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(WorkloadGroupStatement)");
        }

        public override void Visit(WriteTextStatement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WriteTextStatement)");
            base.Visit(node);
            Console.WriteLine("End Visit(WriteTextStatement)");
        }

        public override void Visit(WsdlPayloadOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(WsdlPayloadOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(WsdlPayloadOption)");
        }

        public override void Visit(XmlDataTypeReference node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(XmlDataTypeReference)");
            base.Visit(node);
            Console.WriteLine("End Visit(XmlDataTypeReference)");
        }

        public override void Visit(XmlForClause node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(XmlForClause)");
            base.Visit(node);
            Console.WriteLine("End Visit(XmlForClause)");
        }

        public override void Visit(XmlForClauseOption node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(XmlForClauseOption)");
            base.Visit(node);
            Console.WriteLine("End Visit(XmlForClauseOption)");
        }

        public override void Visit(XmlNamespaces node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(XmlNamespaces)");
            base.Visit(node);
            Console.WriteLine("End Visit(XmlNamespaces)");
        }

        public override void Visit(XmlNamespacesAliasElement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(XmlNamespacesAliasElement)");
            base.Visit(node);
            Console.WriteLine("End Visit(XmlNamespacesAliasElement)");
        }

        public override void Visit(XmlNamespacesDefaultElement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(XmlNamespacesDefaultElement)");
            base.Visit(node);
            Console.WriteLine("End Visit(XmlNamespacesDefaultElement)");
        }

        public override void Visit(XmlNamespacesElement node)
        {
            if(doVisitPrint == false)
            {
                return;
            }
            Console.WriteLine("Start Visit(XmlNamespacesElement)");
            base.Visit(node);
            Console.WriteLine("End Visit(XmlNamespacesElement)");
        }
    }
}
